using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointRotation : MonoBehaviour {
    public GameObject sun; //centre of the rotation
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        orbitate();
	}

    void orbitate()
    {
        transform.RotateAround(sun.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
    public void ResetPos()
    {

    }
}
