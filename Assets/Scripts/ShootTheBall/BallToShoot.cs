using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToShoot : MonoBehaviour
{
    [Header("Target stats")]
    public bool isTarget = false;
    public bool hasBeenShooted = false;
    public Color ballColor;
    public AudioSource hitSound;
    [Header("Complements")]
    public GameObject lookAt;
    public ShootTheBall gameManager;
    public List<GameObject> neightbours = new List<GameObject>();

    [Header("Line")]
    public GameObject line;

    Renderer m_Renderer;
    // Use this for initialization
    void Start ()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();
        gameManager = GameObject.Find("Game").GetComponent<ShootTheBall>();

        lookAt = GameObject.Find("ControlCamera");
        this.transform.LookAt(lookAt.transform);

        hitSound = this.GetComponent<AudioSource>();
	}
	
    public void createLines()
    {
        //CreateNeightbourLines
        foreach (GameObject l_Object in neightbours)
        {
            GameObject l_Line = Instantiate(line, this.transform.position, Quaternion.identity, this.transform) as GameObject;
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
        GameObject l_Line = Instantiate(line, this.transform.position, Quaternion.identity, this.transform) as GameObject;
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
        if(_col.gameObject.name=="Bullet" && isTarget)
        {
            hitSound.Play();
            hasBeenShooted = true;
            isTarget = false;
            m_Renderer.material.color = ballColor;
            Destroy(_col.gameObject);
            gameManager.addScore(1);
        }
    }
}
