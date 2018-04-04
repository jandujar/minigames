using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTheWorld : IMiniGame {

    private GameManager gameManager;
    public Transform canvas;
    public MissileController missile;

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        canvas.gameObject.SetActive(true);
        missile.StartGame(gameManager);
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
