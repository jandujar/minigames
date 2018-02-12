using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFlip : IMiniGame {
    private GameManager gameManager;

    void Awake()
    {
        //Init Pong
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "BottleFlip by MarcAlfonso";
    }
}
