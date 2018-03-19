using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {


    public float shootForce = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(shootForce * Vector3.forward);
    }
}
