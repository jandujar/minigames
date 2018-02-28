using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointRotation : MonoBehaviour {
    public GameObject sun; //centre of the rotation
    public float speed;


    private Vector3 initPos;
    private int direction;

	// Use this for initialization
	void Start () {
        direction = -1;
        speed = 100;
	}
	
	// Update is called once per frame
	void Update () {
        orbitate();
        Debug.Log(transform.rotation.z);
    }

    void orbitate()
    {
        transform.RotateAround(sun.transform.position, Vector3.forward, speed * Time.deltaTime * direction);
        /*
        if(transform.rotation.z >= -0.70 && transform.rotation.z  <= -0.68)
        {
            direction = direction * -1;
        }else if (transform.rotation.z <= 0.1 && transform.rotation.z >= 0)
        {
            direction = direction * -1;
        }*/
    }

    public void setDirection(int value)
    {
        direction = value;
    }
    public int getDirection()
    {
        return direction;
    }
}