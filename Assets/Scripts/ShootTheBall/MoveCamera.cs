using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Movement pivot")]
    public Transform gameCamera;
    public Transform gameGun;
        
    [Header("Sensibility")]
    public float sensibility = 2f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("H: " + Input.GetAxis("Horizontal") + " - V: " + Input.GetAxis("Vertical"));
        gameCamera.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * sensibility));
        gameGun.Rotate(Vector3.right * ((Input.GetAxis("Vertical") * -1) * sensibility));
        
        //Camara
        if (gameCamera.localRotation.eulerAngles.y <= 286f && gameCamera.localRotation.eulerAngles.y >= 280f)
        {
            Vector3 l_CurrentCamaraRotation = new Vector3(0f, 285f, 0f);
            gameCamera.localRotation = Quaternion.Euler(l_CurrentCamaraRotation);
        }
        if (gameCamera.localRotation.eulerAngles.y <= 80f && gameCamera.localRotation.eulerAngles.y >= 70f)
        {
            Vector3 l_CurrentCamaraRotation = new Vector3(0f, 70f, 0f);
            gameCamera.localRotation = Quaternion.Euler(l_CurrentCamaraRotation);
        }

        //Gun
        if (gameGun.localRotation.eulerAngles.x <= 333f && gameGun.localRotation.eulerAngles.x >= 325f)
        {
            Vector3 l_CurrentGunRotation = new Vector3(333f, 0f, 0f);
            gameGun.localRotation = Quaternion.Euler(l_CurrentGunRotation);
        }
        if (gameGun.localRotation.eulerAngles.x <= 30f && gameGun.localRotation.eulerAngles.x >= 20f)
        {
            Vector3 l_CurrentGunRotation = new Vector3(20f, 0f, 0f);
            gameGun.localRotation = Quaternion.Euler(l_CurrentGunRotation);
        }

    }
}
