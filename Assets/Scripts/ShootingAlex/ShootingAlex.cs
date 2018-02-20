﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlex: IMiniGame {
    private GameManager gameManager;
	public GameObject shooting;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
		shooting.GetComponent<ShootingManager> ().InitGame (gameManager);
        //ball.enableBall = true;

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
		if (difficulty == MiniGameDificulty.EASY) {
			shooting.GetComponent<ShootingManager> ().setTimeRecolectObjective (2.5f);
		} else {
			if (difficulty == MiniGameDificulty.NORMAL) {
				shooting.GetComponent<ShootingManager> ().setTimeRecolectObjective (2f);
			} else {
				shooting.GetComponent<ShootingManager> ().setTimeRecolectObjective (1.5f);
			}
		}
        //ball.init(gm); 
    }

    public override string ToString()
    {
        return "Shooting by Alex";
    }
}
