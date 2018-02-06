using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IroGuitar : IMiniGame
{
    private GameManager gameManager;
    
    public float m_Time;
    public int m_MinRand;
    public int m_MaxRand;

    public BallSpawn m_NoteSpawner;

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
        //baru.init(gm); 
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }

    private void Update()
    {

    }

    
}
