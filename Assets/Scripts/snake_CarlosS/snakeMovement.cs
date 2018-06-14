using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeMovement : MonoBehaviour {

    public float Speed;
    public float RotationSpeed;

    public GameObject[] tailObject = new GameObject[1];

    public float z_offset = -0.5f;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;
    public GameObject coin9;
    public GameObject coin10;
    public GameObject coin11;
    public GameObject coin12;
    public GameObject coin13;
    public GameObject coin14;
    public GameObject coin15;
    public GameObject coin16;
    public GameObject coin17;
    public GameObject coin18;
    public GameObject coin19;
    public GameObject coin20;


    // Use this for initialization
    void Start () {

     
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1 * RotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("1"))

        {
            Debug.Log("hola");
            coin1.gameObject.SetActive(false);
            coin2.gameObject.SetActive(true);
        }
    }

   
}

