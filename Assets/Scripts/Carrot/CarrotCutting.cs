using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCutting : IMiniGame {
    private GameManager gameManager;
    public Carrot carrot;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Carrot Begins
        Debug.Log(this.ToString() + " game Begin");
        carrot.enableCarrot = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        carrot.init(gm); 
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }
}
