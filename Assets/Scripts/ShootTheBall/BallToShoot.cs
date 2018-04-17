using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToShoot : MonoBehaviour
{
    [Header("Target stats")]
    public bool m_IsTarget = false;
    public bool m_HasBeenShooted = false;
    public Color m_BallColor;
    [Header("Complements")]
    public GameObject m_LookAt;
    public ShootTheBall m_GameManager;
    public List<GameObject> m_Neightbours = new List<GameObject>();

    [Header("Line")]
    public GameObject m_Line;

    Renderer m_Renderer;
    // Use this for initialization
    void Start ()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();
        m_GameManager = GameObject.Find("Game").GetComponent<ShootTheBall>();

        m_LookAt = GameObject.Find("ControlCamera");
        this.transform.LookAt(m_LookAt.transform);
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
    public void createLineToPoint(GameObject _target, Color _lineColor)
    {
        GameObject l_Line = Instantiate(m_Line, this.transform.position, Quaternion.identity, this.transform) as GameObject;
        l_Line.gameObject.name = "Line";
        LineRenderer l_LineRender = l_Line.GetComponent<LineRenderer>();
        l_LineRender.startColor=_lineColor;
        l_LineRender.endColor = _lineColor;
        //Debug.Log("Object pos" + l_Object.transform.position + " / " + l_Object.transform.localPosition);
        l_LineRender.SetPosition(0, this.transform.position);
        l_LineRender.SetPosition(1, _target.transform.position);
        l_LineRender.useWorldSpace = true;
        l_LineRender.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.name=="Bullet" && m_IsTarget)
        {
            m_HasBeenShooted = true;
            m_IsTarget = false;
            m_Renderer.material.color = m_BallColor;
            Destroy(_col.gameObject);
            m_GameManager.addScore(1);
        }
    }
}
