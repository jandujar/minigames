using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int hitScore = 50;
    public Text text;

    void Awake()
    {
        //Init Game
    }

    public override void beginGame()
    {
        //Iro Hiro Begins
        Debug.Log(this.ToString() + " game Begin");
        text.text = " ";
        StartCoroutine(noteSpawner.generateRandom(time, minRand, maxRand));
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
        //score += 1;
    }

    public void setEndGame()
    {
        gameManager.EndGame(MiniGameResult.LOSE);
        StopAllCoroutines();
    }

    public void addScore()
    {
        score+=hitScore;
    }    
}
