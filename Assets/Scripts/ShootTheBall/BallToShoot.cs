using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToShoot : MonoBehaviour
{
    [Header("Target stats")]
    public bool m_IsTarget = false;
    public bool m_HasBeenShooted = false;

    [Header("Complements")]
    public List<GameObject> m_Neightbours = new List<GameObject>();

    [Header("Line")]
    public GameObject m_Line;

    Renderer m_Renderer;
    // Use this for initialization
    void Start ()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();
        //createLines();
	}
	
    public void createLines()
    {
        //CreateNeightbourLines
        foreach (GameObject l_Object in m_Neightbours)
        {
            GameObject l_Line = Instantiate(m_Line, this.transform.position, Quaternion.identity, this.transform) as GameObject;
            l_Line.gameObject.name = "Line";
            LineRenderer l_LineRender = l_Line.GetComponent<LineRenderer>();
            //Debug.Log("Object pos" + l_Object.transform.position + " / " + l_Object.transform.localPosition);
            l_LineRender.SetPosition(0, this.transform.position);
            l_LineRender.SetPosition(1, l_Object.transform.position);
            l_LineRender.useWorldSpace = true;
        }
    }
    public void createLineToPoint(GameObject _target)
    {
        GameObject l_Line = Instantiate(m_Line, this.transform.position, Quaternion.identity, this.transform) as GameObject;
        l_Line.gameObject.name = "Line";
        LineRenderer l_LineRender = l_Line.GetComponent<LineRenderer>();
        //Debug.Log("Object pos" + l_Object.transform.position + " / " + l_Object.transform.localPosition);
        l_LineRender.SetPosition(0, this.transform.position);
        l_LineRender.SetPosition(1, _target.transform.position);
        l_LineRender.useWorldSpace = true;
    }

    private void OnTriggerEnter(Collider _col)
    {
        Debug.Log(_col.gameObject.name);
        if(_col.gameObject.name=="Bullet" && m_IsTarget)
        {
            m_HasBeenShooted = true;
            m_IsTarget = false;
            m_Renderer.material.color = Color.blue;
            Destroy(_col.gameObject);
        }
    }
}
