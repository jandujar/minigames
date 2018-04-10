using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDodge : IMiniGame
{
    private GameManager gameManager;
    

    void Awake()
    {
        //Init 
        Debug.Log("init");
    }

    public override void beginGame()
    {
        //Game Begins
        Debug.Log(this.ToString() + " game Begin");
      
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        Debug.Log("!");
    }

    public void Lose()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

    public void Win()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    public override string ToString()
    {
        return "CubeDodge by Raul";
    }
}
