using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDoorRay : MonoBehaviour {

    //PUBLIC



    //PRIVATE

    private Ray rayHit;


	// Use this for initialization
	void Start () {
	    rayHit = new Ray(transform.position, Vector3.down);
    }
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
	}
}
