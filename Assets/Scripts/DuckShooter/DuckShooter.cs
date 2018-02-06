using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShooter : IMiniGame{
    private GameManager gameManager;
    public DuckSpawn spawn;
    

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        spawn.init(gm);
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }
}
