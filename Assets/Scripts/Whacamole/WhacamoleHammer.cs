using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleHammer : MonoBehaviour {

    private float moveX;
    private float moveY;
    private float moveZ;
    private float incrementX;
    private float incrementY;
    private float speed = 10;


	// Use this for initialization
	void Start () {
        moveX = transform.position.x;
        moveY = transform.position.y;
        moveZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        incrementX = InputManager.Instance.GetAxisHorizontal()*3;
        incrementY = InputManager.Instance.GetAxisVertical()*3;
        transform.Translate(incrementX * speed * Time.deltaTime, 0, incrementY * speed * Time.deltaTime);
    }
}
