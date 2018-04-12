using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRB : MonoBehaviour {
	public Vector3[] positions;
	private int currentPos;

	private bool win;

	// Use this for initialization
	void Start () {
		currentPos = 1; 
		win = true;
		StartCoroutine(WinCele());
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")){
			currentPos--;
			if(currentPos <= 0){
				currentPos = 0;
			}
			transform.position = positions[currentPos];
		}
		if(Input.GetButtonDown("Fire1")){
			currentPos++;
			if(currentPos >= 2){
				currentPos = 2;
			}
			transform.position = positions[currentPos];
		}
	}

	IEnumerator WinCele(){
		yield return new WaitForSeconds(23);
		if(win){
			Debug.Log("YouWonGG");
		}else{
			Debug.Log("Mek");
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Cube"){
			gameObject.transform.position = new Vector3(300,300,300);
			win = false;
		}
	}

}
