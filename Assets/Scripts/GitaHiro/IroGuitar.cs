using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IroGuitar : IMiniGame {
    private GameManager gameManager;

    public GameObject m_X;
    public GameObject m_Sound;
    public Ball baru;

    public float m_Time;
    public int m_MinRand;
    public int m_MaxRand;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        baru.enableBall = true;
        StartCoroutine(generateRandom(m_Time, m_MinRand, m_MaxRand));
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        baru.init(gm); 
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(m_Sound, m_X.transform.position, Quaternion.identity);
        }
    }

    IEnumerator generateRandom(float _time,int _maxValue,int _minValue)
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(_time);
            int l_Rand = 0;
            Debug.Log(l_Rand);
        }
    }
}
