using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
	public LayerMask groundLayer;

	public bool isGrounded(){
		Debug.DrawRay(transform.position, Vector2.down, Color.green);

		RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.down, 0.45f, groundLayer);

		if (hit.collider != null) {	
			return true;
		}
		return false;
	}
}
