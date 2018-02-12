using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitaHiro : IMiniGame
{
    private GameManager gameManager;
    
    [Header("Note Spawner")]
    public float m_Time;
    public int m_MinRand;
    public int m_MaxRand;
    public BallSpawn m_NoteSpawner;
    [Header("Score")]
    public int m_Score;

    void Awake()
    {
        //Init Game
    }

    public override void beginGame()
    {
        //Iro Hiro Begins
        Debug.Log(this.ToString() + " game Begin");
        StartCoroutine(m_NoteSpawner.generateRandom(m_Time, m_MinRand, m_MaxRand));
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

    }

    public void setEndGame()
    {
        gameManager.EndGame(MiniGameResult.LOSE);
    }
    public void addScore(int _score)
    {
        m_Score += _score;
    }

    
}
