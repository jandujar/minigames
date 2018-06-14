using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
	public float moveSpeed = 5;
	private int size = 0;
	private bool blockInput;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckInputs ();
		Move ();
		Debug.Log (blockInput);
	}


	private void CheckInputs(){
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1)) {
			//Gira izq
			transform.Rotate(0,-90,0);
		}
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON2)) {
			//Gira izq
			transform.Rotate(0,90,0);
		}
	}
	private void Move(){
		transform.Translate (transform.forward * moveSpeed * Time.deltaTime,Space.World);
	}
}
