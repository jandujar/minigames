using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whakamoleMove : MonoBehaviour {

    //PUBLIC
    public int speed;

    //PRIVATE 

    private float initialPositionX;
    private float initialPositionY;
    private float initialPositionZ;



	// Use this for initialization
	void Start () {
        initialPositionX = transform.position.x;
        initialPositionY = transform.position.y;
        initialPositionZ = transform.position.z;

	}
	
    void Update()
    {

    }

}
