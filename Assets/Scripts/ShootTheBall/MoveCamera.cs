using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform m_Camera;
    public Transform m_Gun;

    public float m_Sensibility = 2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("H: " + Input.GetAxis("Horizontal") + " - V: " + Input.GetAxis("Vertical"));
        m_Camera.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * m_Sensibility));
        m_Gun.Rotate(Vector3.right * ((Input.GetAxis("Vertical") * -1) * m_Sensibility));
    }
}
