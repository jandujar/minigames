using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutter : IMiniGame {
    public static WoodCutter instance = null;
    public RamaInstance ramaInstance;

    bool isCutting = false;
    int cuttedCount = 0;
    public int cuttedToWin = 20;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (getIsCutting())
        {
            ramaInstance.init();
        }
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        //ball.enableBall = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
       ramaInstance.init();
    }

    public override string ToString()
    {
        return "Wood Cutter by Sergi López Dorador";
    }

    public void setIsCutting(bool cutting)
    {
        isCutting = cutting;
    }

    public bool getIsCutting()
    {
        return isCutting;
    }

    public void setCuttedCount(int count)
    {
        cuttedCount = count;
    }
    public int getCuttedCount()
    {
        return cuttedCount;
    }

    public int getCuttedToWin()
    {
        return cuttedToWin;
    }

}

