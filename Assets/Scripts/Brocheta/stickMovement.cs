using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickMovement : MonoBehaviour {

    public GameObject leftSpawn;
    public GameObject rightSpawn;


    void move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * -50.0f;
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //stick.transform.Rotate(0, x, 0);
        transform.Translate(0, 0, x);
    }
	

	void Update () {
        move();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "left")
        {
            Debug.Log("entró en left");
            gameObject.transform.position = leftSpawn.transform.position;
        } else if (other.name == "right")
        {
            Debug.Log("entró en right");
            gameObject.transform.position = rightSpawn.transform.position;
        }
    }
}
