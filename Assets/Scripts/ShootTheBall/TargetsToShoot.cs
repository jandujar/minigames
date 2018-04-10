using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsToShoot : MonoBehaviour
{
    [Header("Game Controller")]
    public ShootTheBall gameManager;
    [Header("Childs list")]
    public List<GameObject> m_Targets = new List<GameObject>();
    [Header("Path Target")]
    public int m_PathSize = 0;
    public List<GameObject> m_PathTargets = new List<GameObject>();
    [Header("Target")]
    public int timesToShoot = 3;
    public GameObject m_Target;
    public BallToShoot m_BallTarget;
    public Renderer m_TargetRenderer;
    [Header("Timers")]
    public float startCreatePath = 4f;
    public float timeToNextPath = 6f;
    
    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("Game").GetComponent<ShootTheBall>();
        setAllTargetsColor();
        StartCoroutine(SetTarget());
    }

    void setAllTargetsColor()
    {
        foreach (Transform l_Child in gameObject.transform)
        {
            Renderer l_Renderer = l_Child.gameObject.GetComponent<Renderer>();
            l_Renderer.material.color = Color.blue;
            m_Targets.Add(l_Child.gameObject);
        }
    }

    bool createPath()
    {
        setAllTargetsColor();
        destroyChildrensOnList();

        m_PathTargets.Clear();
        //Select 1rst path point
        BallToShoot l_RandomObject = m_Targets[Random.Range(0, m_Targets.Count)].GetComponent<BallToShoot>();
        m_PathTargets.Add(l_RandomObject.gameObject);

        //Next path points until fill list
        for (int i=0;i<m_PathSize;++i)
        {
            //Reference to last obj
            BallToShoot l_PrevObj = l_RandomObject;
            //Next point on neightbours
            l_RandomObject = l_PrevObj.m_Neightbours[Random.Range(0, l_PrevObj.m_Neightbours.Count)].GetComponent<BallToShoot>();

            //Check if is on list

            //Neightbours count
            int l_Neightbours = l_PrevObj.m_Neightbours.Count;
            while(true)
            {
                //If no neightbours, fails
                if (l_Neightbours <= 0)
                    return false;

                //If invalid point
                if (m_PathTargets.Contains(l_RandomObject.gameObject))
                {
                    l_Neightbours--;
                    l_RandomObject = l_PrevObj.m_Neightbours[Random.Range(0, l_PrevObj.m_Neightbours.Count)].GetComponent<BallToShoot>();
                }
                //If correct
                else
                    break;
            }
            //add point
            m_PathTargets.Add(l_RandomObject.gameObject);
        }
        StartCoroutine(createPathLines());
        return true;
    }

    void destroyChildrensOnList()
    {
        foreach (GameObject l_PathTarget in m_PathTargets)
            foreach (Transform l_Child in l_PathTarget.transform)
                GameObject.Destroy(l_Child.gameObject);
    }

    IEnumerator createPathLines()
    {
        BallToShoot l_PathPoint = m_PathTargets[0].GetComponent<BallToShoot>();
        for(int i=1;i<m_PathTargets.Count;++i)
        {
            BallToShoot l_NextPoint = m_PathTargets[i].GetComponent<BallToShoot>();
            l_PathPoint.createLineToPoint(l_NextPoint.gameObject);
            if(i!=m_PathTargets.Count-1)
                yield return new WaitForSecondsRealtime(0.35f);
            l_PathPoint = l_NextPoint;
        }
        setBallTarget();
    }

    void setBallTarget()
    {
        m_BallTarget = m_PathTargets[m_PathTargets.Count-1].GetComponent<BallToShoot>();
        m_TargetRenderer = m_BallTarget.gameObject.GetComponent<Renderer>();
        m_TargetRenderer.material.color = Color.green;

        m_BallTarget.m_IsTarget = true;
    }

    public IEnumerator SetTarget()
    {
        yield return new WaitForSecondsRealtime(startCreatePath);

        for(int i=0;i<timesToShoot;++i)
        {
            while(!createPath())
                Debug.Log(".");
            yield return new WaitForSecondsRealtime(timeToNextPath);
        }
        gameManager.checkWinLose();
    }
}
