using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTheWorld : IMiniGame {

    private GameManager gameManager;
    public Transform canvas;

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        canvas.gameObject.SetActive(true);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "End The World by DarkJoe";
    }
}
