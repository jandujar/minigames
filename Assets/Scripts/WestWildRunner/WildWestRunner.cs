using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunner: IMiniGame {
    private GameManager gameManager;
	public GameObject wildWestManager;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
		wildWestManager.GetComponent<WildWestRunnerManager> ().InitGame (gameManager);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
		if (difficulty == MiniGameDificulty.EASY) {
			wildWestManager.GetComponent<WildWestRunnerManager> ().setGoalScore (1000);
		} else {
			if (difficulty == MiniGameDificulty.NORMAL) {
				wildWestManager.GetComponent<WildWestRunnerManager> ().setGoalScore (2500);
			} else {
				wildWestManager.GetComponent<WildWestRunnerManager> ().setGoalScore (5000);
			}
		}
        //ball.init(gm); 
    }

    public override string ToString()
    {
        return "Shooting by Alex";
    }
}
