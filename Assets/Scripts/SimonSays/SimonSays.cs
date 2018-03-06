using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays: IMiniGame {
	private GameManager gameManager;
	public GameObject simonSaysManag;

	void Awake()
	{
		//Init Pong
		Debug.LogError("Change this Script for your own Script");
	}

	public override void beginGame()
	{
		//Pong Begins
		Debug.Log(this.ToString() + " game Begin");
		simonSaysManag.GetComponent<ManagerSimonSays> ().InitGame (gameManager);
		//ball.enableBall = true;

	}

	public override void initGame(MiniGameDificulty difficulty, GameManager gm)
	{
		this.gameManager = gm;
		if (difficulty == MiniGameDificulty.EASY) {
			simonSaysManag.GetComponent<ManagerSimonSays> ().setNumRepeat (5);
		} else {
			if (difficulty == MiniGameDificulty.NORMAL) {
				simonSaysManag.GetComponent<ManagerSimonSays> ().setNumRepeat (10);
			} else {
				simonSaysManag.GetComponent<ManagerSimonSays> ().setNumRepeat (15);
			}
		}
		//ball.init(gm); 
	}

	public override string ToString()
	{
		return "Simon Says By Alex";
	}
}

