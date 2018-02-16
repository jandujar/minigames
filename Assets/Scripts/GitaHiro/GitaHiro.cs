using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GitaHiro : IMiniGame
{
    private GameManager gameManager;
    
    [Header("Note Spawner")]
    public float time;
    public int minRand;
    public int maxRand;
    public BallSpawn noteSpawner;

    [Header("Score")]
    public int score = 0;
    public Text text;
    
    public override void beginGame()
    {
        //Iro Hiro Begins
		minRand = 1;
		maxRand = 5;
        Debug.Log(this.ToString() + " game Begin");
        noteSpawner.GenerateRandomJand(time, minRand, maxRand);
        text.enabled = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Gita Hiro by Saltimbanqi";
    }

    private void Update()
    {
        text.text = "Score: "+score;
    }

    public void setEndGame()
    {
        StopAllCoroutines();
        gameManager.EndGame(MiniGameResult.LOSE);
    }

    public void addScore()
    {
        score+=1;
    }    
}
