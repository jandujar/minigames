using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour {

	//List All objective
	private GameObject[] objective;
	//Time to recolect objective
	private float timeRecolectObjective;
	//Temporal Var to save Time
	private float tmpTime;
	//Var Lapsus Tiempo
	private float lapsusTime;
	//Number of objective to move
	private int numObjective;
	//Game Is Ready
	private bool gameReady;

	void Awake(){
		//Search for all 
		objective = GameObject.FindGameObjectsWithTag("Objective");
		gameReady = false;
	}
		
	public void InitGame(){
		tmpTime = Time.time;
		lapsusTime = Random.Range (0.5f, 1.5f);
		numObjective = Random.Range (0, objective.Length);
		gameReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (gameReady + " , " + lapsusTime);
		if (Time.time - tmpTime > lapsusTime && gameReady) {
			gameReady = false;
			objective [numObjective].GetComponent<Objective>().moveUp();
			Debug.Log ("Objective To Up: ");
		}
	}

	//*******************************************************************************************SETTERS
	public void setTimeRecolectObjective(float time){
		timeRecolectObjective = time;
	}

}
