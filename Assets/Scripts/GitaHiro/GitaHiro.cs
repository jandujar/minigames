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

    [Header("Game Time")]
    public int gameTime = 10;
    public bool gameSpawnStop = false;
    public Text gameTimeText;
    private AudioSource gameSound;

    void Start()
    {
        gameSound = GetComponent<AudioSource>();
    }
    public override void beginGame()
    {
        //Iro Hiro Begins
		minRand = 1;
		maxRand = 5;
        Debug.Log(this.ToString() + " game Begin");
        noteSpawner.GenerateRandomJand(time, minRand, maxRand);
        text.enabled = true;
        StartCoroutine(gameTimer());
        gameSound.Play();
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

    public IEnumerator gameTimer()
    {
        for(int i=gameTime;i!=0;--i)
        {
            yield return new WaitForSeconds(1f);
            //gameTimeText.text = i.ToString();
            Debug.Log(i);
            if(i==0)
            {
                gameSpawnStop = true;
            }
        }
    }
    public bool getEndTime()
    {
        return gameSpawnStop;
    }
}
