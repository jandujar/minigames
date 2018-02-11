using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckles : MonoBehaviour {
	public float moveSpeed = 2;
	public float endPosition = 2.2f;
	private bool vertical = true;
	private bool moving = false;
	public DoYouKnowTheWay dyktw;
	private bool correctWay = false;

	//*************************************************************************************************
	void Update () {
		if (moving) {
			Move ();
		}
	}

	//*************************************************************************************************
	public void StartMoving(DoYouKnowTheWay _dyktw){
		moving = true;
		dyktw = _dyktw;
	}

	//*************************************************************************************************
	public bool isMoving(){
		return moving;
	}
	//*************************************************************************************************
	private void Move(){
		if (transform.position.y < endPosition) {
			if (vertical) {
				transform.Translate (0, moveSpeed * Time.deltaTime, 0);
			} else {
				transform.Translate (moveSpeed * Time.deltaTime, 0, 0);
			}
		} else {
			moving = false;
			dyktw.MovementFinished (correctWay);
		}
	}

	//*************************************************************************************************
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Uganda") {
			correctWay = true;
		} 

		//Si colisiona con una interseccion
		else {
			//si va en vertical gira
			if (vertical) {
				if (col.gameObject.name == "left") {
					Debug.Log ("AMIGOOOO");
					moveSpeed = Mathf.Abs (moveSpeed);
				} else {
					moveSpeed = moveSpeed * -1;
				}
				vertical = false;
			}
			//si va en horizontal sube
			else {
				moveSpeed = Mathf.Abs (moveSpeed);
				vertical = true;
			}

		}
	}
}
