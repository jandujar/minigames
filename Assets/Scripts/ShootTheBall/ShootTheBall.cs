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
    public int scoreObjetive = 2;
    private int gameScore = 0;
    [Header("Game Components")]
    public List<GameObject> gameSceneObjects;
    
    void Start()
    {
        gameStarted = false;
        foreach (GameObject aObject in gameSceneObjects)
            aObject.SetActive(false);
    }
    public override void beginGame()
    {
        gameStarted = true;
        //KauboiDueru Begins
        Debug.Log(this.ToString() + " game Begin");
        foreach (GameObject aObject in gameSceneObjects)
            aObject.SetActive(true);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Shoot The Ball by Saltimbanqi";
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

    public void checkWinLose()
    {
        if (gameScore >= scoreObjetive)
            setEndGameWin();
        else
            setEndGameLose();
    }

    public void addScore(int _score)
    {
        gameScore += _score;
    }
}
