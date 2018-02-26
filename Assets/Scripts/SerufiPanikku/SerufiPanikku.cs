using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SerufiPanikku : IMiniGame
{
    private GameManager gameManager;

    public SerufiImgManager phoneImage;

    void Start()
    {
        
    }

    public override void beginGame()
    {
        //Serufi Panikku Begins
        Debug.Log(this.ToString() + " game Begin");
        StartCoroutine(phoneImage.changeImgTest());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Serufi Panikku by Saltimbanqi";
    }

    private void Update()
    {

    }

    public void setEndGame()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.LOSE);
    }

    void setEndGameWin()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.WIN);
    }
}
