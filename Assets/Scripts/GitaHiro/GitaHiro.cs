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
        StartCoroutine(noteSpawner.generateRandom(time, minRand, maxRand));
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
#if UNITY_EDITOR
        SceneManager.LoadScene("GitaHiro");
        StopAllCoroutines();
#else
        gameManager.EndGame(MiniGameResult.LOSE);
        StopAllCoroutines();
#endif
    }

    public void addScore()
    {
        score+=hitScore;
    }    
}
