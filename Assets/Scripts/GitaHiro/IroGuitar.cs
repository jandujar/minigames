using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IroGuitar : IMiniGame {
    private GameManager gameManager;
    public Baru baru;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        baru.enableBall = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        baru.init(gm); 
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }
}
