using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsToShoot : MonoBehaviour
{
    public List<GameObject> m_Targets = new List<GameObject>();

    public BallToShoot m_BallTarget;
    private BallToShoot m_NextTarget;

    public Renderer m_TargetRenderer;

    public GameObject m_Target;

    public int m_PathSize = 0;
    public bool m_LookTarget = false;

    public List<GameObject> m_PathTargets = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
	    foreach(Transform l_Child in gameObject.transform)
        {
            Renderer l_Renderer = l_Child.gameObject.GetComponent<Renderer>();
            l_Renderer.material.color = Color.blue;
            m_Targets.Add(l_Child.gameObject);
        }
        StartCoroutine(SelectTarget());
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Random: " + Random.Range(0, (m_Targets.Count)));
        if(m_BallTarget!=null)
            if(!m_BallTarget.m_IsTarget && m_BallTarget.m_HasBeenShooted)
            {
                StartCoroutine(SelectTarget());
            }
	}

    IEnumerator SelectTarget()
    {
        foreach(GameObject l_PathTarget in m_PathTargets)
            foreach (Transform l_Child in l_PathTarget.transform)
                GameObject.Destroy(l_Child.gameObject);

        m_PathTargets.Clear();
        BallToShoot randomObject = m_Targets[Random.Range(0, m_Targets.Count)].GetComponent<BallToShoot>();
        m_PathTargets.Add(randomObject.gameObject);
        for(int i=0;i<m_PathSize;++i)
        {
            Debug.Log(i);
            BallToShoot prevObject = randomObject;
            randomObject = prevObject.m_Neightbours[Random.Range(0, prevObject.m_Neightbours.Count)].GetComponent<BallToShoot>();
            bool l_CheckObject=false;
            while (!l_CheckObject)
            {
                if (m_PathTargets.Contains(randomObject.gameObject))
                    randomObject = prevObject.m_Neightbours[Random.Range(0, prevObject.m_Neightbours.Count)].GetComponent<BallToShoot>();
                else
                    l_CheckObject = true;
            }
            m_PathTargets.Add(randomObject.gameObject);
            if (i != m_PathSize)
            {
                prevObject.createLineToPoint(randomObject.gameObject);
                yield return new WaitForSecondsRealtime(2f);
            }
            //Debug.Break();
            if (i == (m_PathSize-1))
            {
                Debug.Log("Last");
                m_BallTarget = randomObject;
            }
        }
        m_TargetRenderer = m_BallTarget.gameObject.GetComponent<Renderer>();
        m_TargetRenderer.material.color = Color.green;

        m_BallTarget.m_IsTarget = true;
    }

    public IEnumerator SetTarget()
    {
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(SelectTarget());
        /*
        while (true)
        {
            yield return new WaitForSecondsRealtime(5f);
            if(m_BallTarget == null)
            {
                SelectTarget();
            }
            if(!m_BallTarget.m_IsTarget && m_BallTarget.m_HasBeenShooted)
            {
                m_BallTarget.m_HasBeenShooted = false;
                m_BallTarget = null;
            }
        }
        */
    }
}
