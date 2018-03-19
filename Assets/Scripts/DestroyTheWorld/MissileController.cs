using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

    Transform myT;
    private float moveVer;
    private float moveHor;
    public float spd = 10f;
    public float rotationSpd = 1f;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    private Vector3 tmpPosition;
    public DestroyTheWorld gameEngine;

    void Awake()
    {
        myT = transform;
    }
	
	// Update is called once per frame
	void Update () {

        moveVer = -InputManager.Instance.GetAxisVertical();
        moveHor = InputManager.Instance.GetAxisHorizontal();

        Movement();        
    }

    private void Movement()
    {
        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            myT.position += myT.forward * spd * Time.deltaTime;
        }
    }

    private void Limitations()
    {
        if (myT.position.y > maxposy)
        {
            tmpPosition = new Vector3(myT.position.x, maxposy, myT.position.z);
            myT.position = tmpPosition;
        }

        if (myT.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, myT.position.y, myT.position.z);
            myT.position = tmpPosition;
        }

        if (myT.position.y < -maxposy)
        {
            tmpPosition = new Vector3(myT.position.x, -maxposy, myT.position.z);
            myT.position = tmpPosition;
        }

        if (myT.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, myT.position.y, myT.position.z);
            myT.position = tmpPosition;
        }
    }
}
