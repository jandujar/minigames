using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
	public LayerMask groundLayer;
	private bool grounded = false;
	private float distToGround = 0;

	public void OnCollisionEnter2D(Collision2D collision){
		grounded = true;
	}
	public void OnCollisionExit2D(Collision2D collision){
		grounded = false;
	}

	public bool isGrounded(){
		Debug.DrawRay(transform.position, Vector2.down, Color.green);

		RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.down, 0.45f, groundLayer);

		if (hit.collider != null) {	
			return true;
		}
		return false;
	}
}
