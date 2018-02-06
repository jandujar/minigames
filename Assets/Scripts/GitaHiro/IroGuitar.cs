using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IroGuitar : IMiniGame {
    private GameManager gameManager;

    public GameObject m_X;
    public GameObject m_Sound;

    public float m_Time;
    public int m_MinRand;
    public int m_MaxRand;

    public BallSpawn m_NoteSpawner;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        //baru.enableBall = true;
        StartCoroutine(m_NoteSpawner.generateRandom(m_Time, m_MinRand, m_MaxRand));
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        //baru.init(gm); 
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }

    
}
