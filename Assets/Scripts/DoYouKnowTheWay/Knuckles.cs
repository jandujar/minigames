using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckles : MonoBehaviour {
	public float moveSpeed = 2;
	public float endPosition = 2.2f;
	public int actualWay = 0;
	public int lastWay = 0;

	private DoYouKnowTheWay dyktw;
	private bool vertical = true;
	private bool moving = false;
	private bool correctWay = false;
	private Collider2D myCollider = null;

	//*************************************************************************************************
	void Update () {
		if (moving) {
			Move ();
		}
	}

	//*************************************************************************************************
	public void StartMoving(DoYouKnowTheWay _dyktw, int _way){
		myCollider = transform.GetComponent<Collider2D> ();
		moving = true;
		dyktw = _dyktw;
		actualWay = _way;
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
	public IEnumerator desactivateCollider(){
		myCollider.enabled = false;
		yield return new WaitForSecondsRealtime (0.1f);
		myCollider.enabled = true;
	}

	//*************************************************************************************************
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Uganda") {
			correctWay = true;
		} 


	}
	//*************************************************************************************************
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag != "Uganda") {
			//SI VA HACIA ARRIBA
			if (vertical) {
				//SI VA HACIA ARRIBA Y COLISIONA POR IZQUIERDA
				if (col.gameObject.name == "Left") {
					if (transform.position.y >= col.transform.parent.transform.position.y -0.05f) {
						transform.position = new Vector3 (transform.position.x, col.transform.parent.transform.position.y, transform.position.z);
						vertical = false;
						moveSpeed = Mathf.Abs (moveSpeed);
						lastWay = actualWay;
						actualWay++;

					}
				} 
			//SI VA HACIA ARRIBA Y COLISIONA POR DERECHA
			else {
					if (transform.position.y >= col.transform.parent.transform.position.y-0.05f) {
						transform.position = new Vector3 (transform.position.x, col.transform.parent.transform.position.y, transform.position.z);
						vertical = false;
						moveSpeed = moveSpeed * -1;
						lastWay = actualWay;
						actualWay--;
					}
				}
		
			}
		//SI VA EN HORIZONTAL
		else {
				if (lastWay < actualWay) {
					if (transform.position.x >= dyktw.ways[actualWay].transform.position.x-0.05f) {
						transform.position = new Vector3 (dyktw.ways[actualWay].transform.position.x, transform.position.y, transform.position.z);
						moveSpeed = Mathf.Abs (moveSpeed);
						vertical = true;
						StartCoroutine ("desactivateCollider");
					}
				} else {
					if (transform.position.x <= dyktw.ways[actualWay].transform.position.x+0.05f) {
						transform.position = new Vector3 (dyktw.ways[actualWay].transform.position.x, transform.position.y, transform.position.z);
						moveSpeed = Mathf.Abs (moveSpeed);
						vertical = true;
						StartCoroutine ("desactivateCollider");
					}
				}
		

			}
		}
	}




}
