using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoYouKnowTheWay : IMiniGame {
	//PUBLIC
	public int numberOfIntersections = 3;
	public GameObject uganda;
	public GameObject knuckles;
	public Transform[] ways = new Transform[4];

	//PRIVATE
	private int knucklesPos = 0;
	private float h;
	private bool alreadyMoved = false;

	//*************************************************************************************************Start
	public override void beginGame()
	{
		//Pong Begins
		Debug.Log(this.ToString() + " game Begin");
		RandomUgandaPosition ();
	}

	//*************************************************************************************************Update
	void Update () {
		CheckPlayerInput ();
		
	}

	//*************************************************************************************************Check Player Inputs
	private void CheckPlayerInput(){
		h = Input.GetAxis ("Horizontal");
		//Change Knuckeles Pos
		if (!alreadyMoved && h <= -0.1 && knucklesPos > 0) {
			alreadyMoved = true;
			knucklesPos--;
			UpdateKnucklesPos ();
		}
		if (!alreadyMoved && h >= 0.1 && knucklesPos < 3) {
			alreadyMoved = true;
			knucklesPos++;
			UpdateKnucklesPos ();
		}
		if (alreadyMoved && h < 0.1 && h > -0.1) {
			alreadyMoved = false;
		}
		Debug.Log(knucklesPos);
	}

	//*************************************************************************************************Put uganda Randomly
	private void RandomUgandaPosition(){
		int rNumber = Random.Range (0, 4);
		uganda.transform.position = new Vector3 (ways [rNumber].transform.position.x, uganda.transform.position.y, uganda.transform.position.z);
	}

	//*************************************************************************************************Moves Knuckes to start way
	private void UpdateKnucklesPos(){
		knuckles.transform.position = new Vector3 (ways [knucklesPos].transform.position.x, knuckles.transform.position.y, knuckles.transform.position.z);
	}

	//*************************************************************************************************Random Intersection generator
	private void GenerateIntersection(){
		
	}
}
