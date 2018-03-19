using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public GameObject Ball;
    public float speedShoot = 10.0F;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        /*transform.rotate(Vector3.left * speedShoot);

        if(ball.rotate.y == -70)
        {
            transform.rotate(Vector3.right * speedShoot);
        }
        else if (ball.rotate.y == 70)
        {
            transform.rotate(Vector3.left * speedShoot);
        }*/

        transform.Rotate(Vector3.up, speedShoot * Time.deltaTime);

        
       

        
    }

    
}
