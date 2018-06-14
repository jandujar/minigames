using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganKnows : IMiniGame
{
    private GameManager gameManager;
    public Canvas canvasObject;

    void Awake()
    {
        //Init Pong
        Debug.Log("init");
        canvasObject.GetComponent<Canvas>().enabled = true;
    }

    public override void beginGame()
    {
        //Pong Begins
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
        return "Ultimate Bowling by Carlos Sevilla";
    }
}
