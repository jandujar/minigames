using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour {

	private GameManager gm;
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
	//Random is valid or not objective
	private bool valid;

	void Awake(){
		//Search for all 
		objective = GameObject.FindGameObjectsWithTag("Player");
		gameReady = false;
	}
		
	public void InitGame(GameManager manager){
		gm = manager;
		tmpTime = Time.time;
		lapsusTime = Random.Range (0.5f, 1.5f);
		numObjective = Random.Range (0, objective.Length);
		if (Random.Range (0, 10) <= 5) {
			valid = true;
		} else {
			valid = false;
		}
		gameReady = true;
	}

	public void InitGame(){
		tmpTime = Time.time;
		lapsusTime = Random.Range (0.5f, 1.5f);
		numObjective = Random.Range (0, objective.Length);
		if (Random.Range (0, 10) <= 5) {
			valid = true;
		} else {
			valid = false;
		}
		gameReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - tmpTime > lapsusTime && gameReady) {
			gameReady = false;
			objective [numObjective].GetComponent<Objective>().moveUp(valid, timeRecolectObjective);
			Debug.Log ("Objective To Up: ");
		}
	}

	//*******************************************************************************************SETTERS
	public void setTimeRecolectObjective(float time){
		timeRecolectObjective = time;
	}

	public void endGame(IMiniGame.MiniGameResult res){
		gm.EndGame (res);
	}

}
