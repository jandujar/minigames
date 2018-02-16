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
        ActiveCanvas();
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

    public void ActiveCanvas() {
        canvasObject.GetComponent<Canvas>().enabled = true;
    }

    public override string ToString()
    {
        return "Veggie VS Normal by Raul";
    }
}
