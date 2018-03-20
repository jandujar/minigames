using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public GameObject Ball;
    public float speedShoot = 10.0F;
    bool isIn = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
    

        transform.Rotate(Vector3.up, speedShoot * Time.deltaTime);

        if (transform.rotation.y >= 40)
        {
            isIn = false;
            transform.Rotate(Vector3.up, -speedShoot * Time.deltaTime);
            Debug.Log("Not in");
        }
        else if(transform.rotation.y <= -80)
        {
            isIn = false;
            transform.Rotate(Vector3.up, speedShoot * Time.deltaTime);
            Debug.Log("Not in");
        }



    }

    
}
