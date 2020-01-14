using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherGame : IMiniGame {


    void Awake()
    {
        //Init Pong
        
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        
    }

    public override string ToString()
    {
        return "ArcherGame by Berni";
    }
}
