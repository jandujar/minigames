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

    Renderer m_Renderer;
    // Use this for initialization
    void Start ()
    {
        m_Renderer = gameObject.GetComponent<Renderer>();		
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
