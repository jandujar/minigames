using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganKnows : IMiniGame
{
    private GameManager gameManager;
    private VeganPlayer vegan;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        vegan.enableGame = false;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        vegan.init(gm);
    }

    public override string ToString()
    {
        return "Veggie VS Normal by Raul";
    }
}
