using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GitaHiro : IMiniGame
{
    private GameManager gameManager;
    
    [Header("Note Spawner")]
    public float m_Time;
    public int m_MinRand;
    public int m_MaxRand;
    public BallSpawn m_NoteSpawner;

    [Header("Score")]
    public int m_Score = 0;
    public int m_HitScore = 50;
    public Text m_Text;

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
        m_Text.text = "Score: "+m_Score;
    }

    public void setEndGame()
    {
        gameManager.EndGame(MiniGameResult.LOSE);
    }

    public void addScore()
    {
        Debug.LogError("!!!! "+m_HitScore);
        Debug.Break();
        Debug.Log("Adding " + m_HitScore + " to the score");
        m_Score+=m_HitScore;
        Debug.Log("Score added");
    }

    
}
