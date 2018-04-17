using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsToShoot : MonoBehaviour
{
    [Header("Game Controller")]
    public ShootTheBall gameManager;
    [Header("Childs list")]
    public List<GameObject> m_Targets = new List<GameObject>();
    [Header("Childs color")]
    public Color m_BaseColor = Color.white;
    public Color m_TargetColor = Color.white;
    public Color m_LineColor = Color.white;
    [Header("Path Target")]
    public int m_PathSize = 0;
    public List<GameObject> m_PathTargets = new List<GameObject>();
    [Header("Target")]
    public int timesToShoot = 3;
    public BallToShoot m_BallTarget;
    public Renderer m_TargetRenderer;
    [Header("Timers")]
    public float startCreatePath = 4f;
    public float timeToNextPath = 6f;
    public float extraTimeToEnd = 0.75f;
    
    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("Game").GetComponent<ShootTheBall>();
        setChildrensVarsInit();
        setAllTargetsColor();
        StartCoroutine(SetTarget());


    }

    void setChildrensVarsInit()
    {
        foreach (Transform l_Child in gameObject.transform)
        {
            BallToShoot l_Ball = l_Child.GetComponent<BallToShoot>();
            l_Ball.m_BallColor = m_BaseColor;
        }
    }

    void setAllTargetsColor()
    {
        foreach (Transform l_Child in gameObject.transform)
        {
            Renderer l_Renderer = l_Child.gameObject.GetComponent<Renderer>();
            l_Renderer.material.color = m_BaseColor;
            m_Targets.Add(l_Child.gameObject);
        }
    }

    bool createPath()
    {        
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
                if (m_PathTargets.Contains(l_RandomObject.gameObject) || (m_PathTargets.Contains(m_BallTarget.gameObject) && m_BallTarget!=null) )
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
        destroyChildrensOnList();

        BallToShoot l_PathPoint = m_PathTargets[0].GetComponent<BallToShoot>();
        for(int i=1;i<m_PathTargets.Count;++i)
        {
            BallToShoot l_NextPoint = m_PathTargets[i].GetComponent<BallToShoot>();
            l_PathPoint.createLineToPoint(l_NextPoint.gameObject, m_LineColor);
            if(i!=m_PathTargets.Count-1)
                yield return new WaitForSecondsRealtime(0.35f);
            l_PathPoint = l_NextPoint;
        }
        setBallTarget();

        yield return new WaitForSecondsRealtime(0.2f);
        destroyChildrensOnList();
    }

    void setBallTarget()
    {
        setAllTargetsColor();
        
        m_BallTarget = m_PathTargets[m_PathTargets.Count-1].GetComponent<BallToShoot>();
        m_TargetRenderer = m_BallTarget.gameObject.GetComponent<Renderer>();
        m_TargetRenderer.material.color = m_TargetColor;

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
        yield return new WaitForSecondsRealtime(extraTimeToEnd);
        gameManager.checkWinLose();
    }
}
