using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	
	public float tapForce = 10;
	public float rotSpeed = 5;
	public FlappyBird flappyManager;
	Rigidbody2D rigidBody;
	 Quaternion maxDownRot;
	 Quaternion upRotation;
	// Use this for initialization
	void Start () {
		
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.simulated = false;
		maxDownRot = Quaternion.Euler(0, 0 ,-20);
		upRotation = Quaternion.Euler(0, 0, 40);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation, maxDownRot, rotSpeed * Time.deltaTime);

		if (Input.GetMouseButtonDown(0)) {
			rigidBody.velocity = Vector2.zero;
			rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
			transform.rotation = upRotation;
		}
	}

	public void init(){
		rigidBody.simulated = true;
	}

	void OnCollisionEnter2D(Collision2D col){
		flappyManager.EndGame (false);
	}

	void OnTriggerEnter2D(Collider2D col){
		flappyManager.UpdateScore ();
	}
}
