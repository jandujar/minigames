using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public KeyCode spaceKey = KeyCode.Space;
    public float shootForce = 1000;

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(spaceKey))
        {

           

            GetComponent<Rigidbody>().AddForce(shootForce * Vector3.forward);

        }
	}

}
