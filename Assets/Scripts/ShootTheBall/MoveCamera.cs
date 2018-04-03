using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform m_Camera;
    public Transform m_Gun;
        
    [Header("Sensibility")]
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
        
        //Camara
        if (m_Camera.localRotation.eulerAngles.y <= 286f && m_Camera.localRotation.eulerAngles.y >= 280f)
        {
            Vector3 l_CurrentCamaraRotation = new Vector3(0f, 285f, 0f);
            m_Camera.localRotation = Quaternion.Euler(l_CurrentCamaraRotation);
        }
        if (m_Camera.localRotation.eulerAngles.y <= 80f && m_Camera.localRotation.eulerAngles.y >= 70f)
        {
            Vector3 l_CurrentCamaraRotation = new Vector3(0f, 70f, 0f);
            m_Camera.localRotation = Quaternion.Euler(l_CurrentCamaraRotation);
        }

        Debug.Log(m_Gun.localRotation.eulerAngles);
        //Gun
        if (m_Gun.localRotation.eulerAngles.x <= 333f && m_Gun.localRotation.eulerAngles.x >= 325f)
        {
            Vector3 l_CurrentGunRotation = new Vector3(333f, 0f, 0f);
            m_Gun.localRotation = Quaternion.Euler(l_CurrentGunRotation);
        }
        if (m_Gun.localRotation.eulerAngles.x <= 30f && m_Gun.localRotation.eulerAngles.x >= 20f)
        {
            Vector3 l_CurrentGunRotation = new Vector3(20f, 0f, 0f);
            m_Gun.localRotation = Quaternion.Euler(l_CurrentGunRotation);
        }

    }
}
