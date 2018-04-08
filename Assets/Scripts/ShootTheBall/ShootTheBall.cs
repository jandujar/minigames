using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootTheBall : IMiniGame
{
    private GameManager gameManager;

    [Header("Game State")]
    public bool gameStarted;
    [Header("Game Components")]
    public GameObject gameSceneObject;

    void Start()
    {
        gameStarted = false;
        gameSceneObject.SetActive(false);
    }
    public override void beginGame()
    {
        gameStarted = true;
        //KauboiDueru Begins
        Debug.Log(this.ToString() + " game Begin");
        gameSceneObject.SetActive(true);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Shoot the ball by Saltimbanqi";
    }

    private void Update()
    {
    }

    //Set end game Win/Lose
    public void setEndGameLose()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.LOSE);
    }
    public void setEndGameWin()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.WIN);
    }
}
