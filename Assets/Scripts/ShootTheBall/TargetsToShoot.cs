using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsToShoot : MonoBehaviour
{
    [Header("Game Controller")]
    public ShootTheBall gameManager;
    [Header("Childs list")]
    public List<GameObject> targets = new List<GameObject>();
    [Header("Childs color")]
    public Color m_BaseColor = Color.white;
    public Color m_TargetColor = Color.white;
    public Color m_LineColor = Color.white;
    [Header("Path Target")]
    public int pathSize = 9;
    public List<GameObject> pathTargets = new List<GameObject>();
    [Header("Target")]
    public int timesToShoot = 3;
    public BallToShoot ballTarget;
    public Renderer targetRender;
    [Header("Timers")]
    public float startCreatePath = 4f;
    public float timeToNextPath = 6f;
    public float extraTimeToEnd = 0.75f;
    
    // Use this for initialization
    void Start ()
    {
        setChildsList();

        gameManager = GameObject.Find("Game").GetComponent<ShootTheBall>();
        setChildrensVarsInit();
        setAllTargetsColor();
        StartCoroutine(SetTarget());
    }

    void setChildsList()
    {
        foreach (Transform l_Child in gameObject.transform)
            targets.Add(l_Child.gameObject);
    }

    void setChildrensVarsInit()
    {
        foreach (Transform l_Child in gameObject.transform)
        {
            BallToShoot l_Ball = l_Child.GetComponent<BallToShoot>();
            l_Ball.ballColor = m_BaseColor;
        }
    }

    void setAllTargetsColor()
    {
        foreach (Transform l_Child in gameObject.transform)
        {
            Renderer l_Renderer = l_Child.gameObject.GetComponent<Renderer>();
            l_Renderer.material.color = m_BaseColor;
        }
    }

    bool createPath()
    {        
        pathTargets.Clear();

        //Select 1rst path point
        BallToShoot l_RandomObject = targets[Random.Range(0, targets.Count)].GetComponent<BallToShoot>();
        pathTargets.Add(l_RandomObject.gameObject);

        //Next path points until fill list
        for (int i=0;i<pathSize;++i)
        {
            //Reference to last obj
            BallToShoot l_PrevObj = l_RandomObject;
            //Next point on neightbours
            l_RandomObject = l_PrevObj.neightbours[Random.Range(0, l_PrevObj.neightbours.Count)].GetComponent<BallToShoot>();

            //Check if is on list

            //Neightbours count
            int l_Neightbours = l_PrevObj.neightbours.Count;
            while(true)
            {
                //If no neightbours, fails
                if (l_Neightbours <= 0)
                    return false;

                //If invalid point
                if (pathTargets.Contains(l_RandomObject.gameObject) || (pathTargets.Contains(ballTarget.gameObject) && ballTarget!=null) )
                {
                    l_Neightbours--;
                    l_RandomObject = l_PrevObj.neightbours[Random.Range(0, l_PrevObj.neightbours.Count)].GetComponent<BallToShoot>();
                }
                //If correct
                else
                    break;
            }
            //add point
            pathTargets.Add(l_RandomObject.gameObject);
        }
        StartCoroutine(createPathLines());
        return true;
    }

    void destroyChildrensOnList()
    {
        foreach (GameObject l_PathTarget in pathTargets)
            foreach (Transform l_Child in l_PathTarget.transform)
                GameObject.Destroy(l_Child.gameObject);
    }

    IEnumerator createPathLines()
    {
        destroyChildrensOnList();

        BallToShoot l_PathPoint = pathTargets[0].GetComponent<BallToShoot>();
        for(int i=1;i<pathTargets.Count;++i)
        {
            BallToShoot l_NextPoint = pathTargets[i].GetComponent<BallToShoot>();
            l_PathPoint.createLineToPoint(l_NextPoint.gameObject, m_LineColor);
            if(i!=pathTargets.Count-1)
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
        
        ballTarget = pathTargets[pathTargets.Count-1].GetComponent<BallToShoot>();
        targetRender = ballTarget.gameObject.GetComponent<Renderer>();
        targetRender.material.color = m_TargetColor;

        ballTarget.isTarget = true;
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
