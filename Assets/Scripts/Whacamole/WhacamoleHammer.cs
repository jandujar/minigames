using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleHammer : MonoBehaviour {

    private float moveX;
    private float moveY;
    private float moveZ;
    private float incrementX;
    private float incrementY;
    private float speed = 8;


	// Use this for initialization
	void Start () {
        moveX = transform.position.x;
        moveY = transform.position.y;
        moveZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        moveX = transform.position.x;
        moveY = transform.position.y;
        moveZ = transform.position.z;
        incrementX = InputManager.Instance.GetAxisHorizontal()*3;
        incrementY = InputManager.Instance.GetAxisVertical()*3;
        transform.Translate(incrementX * speed * Time.deltaTime, 0, incrementY * speed * Time.deltaTime);
        CheckPos();
    }


    void CheckPos()
    {
        if (transform.position.z > 21.15f)
        {
            transform.position = new Vector3(moveX, 0, 21.14f);
        }
        if (transform.position.z < 15.87f)
        {
            transform.position = new Vector3(moveX, 0, 16);
        }
        if (transform.position.x < -7.1f)
        {
            transform.position = new Vector3(-7, 0, moveZ);
        }
        if (transform.position.x > 7.1f)
        {
            transform.position = new Vector3(7, 0, moveZ);
        }
    }
}

