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
	// Use this for initialization
	void Start ()
    {
	    foreach(Transform l_Child in gameObject.transform)
        {
            Renderer l_Renderer = l_Child.gameObject.GetComponent<Renderer>();
            l_Renderer.material.color = Color.blue;
            m_Targets.Add(l_Child.gameObject);
        }
        StartCoroutine(SetTarget());
        
        for(int i=0;i<25;++i)
        {
            Vector3 l_Pos = (Random.onUnitSphere * 10) + new Vector3(0, 0, -10);
            Instantiate(m_Target, l_Pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Random: " + Random.Range(0, (m_Targets.Count)));
	}

    void SelectTarget()
    {
        bool l_CorrectTarget=false;
        int l_Target = Random.Range(0, m_Targets.Count);
        m_BallTarget = m_Targets[l_Target].gameObject.GetComponent<BallToShoot>();
        while(!l_CorrectTarget)
        {
            if (m_BallTarget == m_NextTarget)
            {
                l_Target = Random.Range(0, m_Targets.Count);
                m_BallTarget = m_Targets[l_Target].gameObject.GetComponent<BallToShoot>();
            }
            else
                l_CorrectTarget = true;
        }
        m_NextTarget = m_BallTarget;

        m_TargetRenderer = m_BallTarget.gameObject.GetComponent<Renderer>();
        m_TargetRenderer.material.color = Color.green;

        m_BallTarget.m_IsTarget = true;
    }

    public IEnumerator SetTarget()
    {
        yield return new WaitForSecondsRealtime(3f);
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
    }
}
