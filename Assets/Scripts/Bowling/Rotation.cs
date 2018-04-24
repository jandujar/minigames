using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public float rotShoot= 10.0F;
    

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {


        if (Input.GetKey(LeftKey))
        {
            transform.Rotate(0, -rotShoot * Time.deltaTime, 0);
        }
        if (Input.GetKey(RightKey))
        {
            transform.Rotate(0, rotShoot * Time.deltaTime, 0);
        }
        if (Input.GetKey(UpKey))
        {
            transform.Rotate(-rotShoot * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(DownKey))
        {
            transform.Rotate(rotShoot * Time.deltaTime, 0, 0);
        }


    }

    
}
