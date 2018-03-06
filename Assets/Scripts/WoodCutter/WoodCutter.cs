using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutter : IMiniGame {
    private GameManager gameManager;

    public static WoodCutter instance = null;
    public RamaInstance ramaInstance;

    bool isCutting = false;
    bool playerDead = false;
    int cuttedCount = 0;
    public int cuttedToWin = 20;

    public TextMesh tTimer;
    float timer = 10;
    int timerInt = 0; 

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
        //Timer - DeltaTime para ver el tiempo que queda
        timer -= Time.deltaTime;
        timerInt = (int)timer; 
        tTimer.text = timerInt.ToString();

        if (timerInt == 0)
        {
            playerDead = true;
        }

        if (getIsCutting() && !playerDead)
        {
            ramaInstance.init();
        }

        if (playerDead)
        {
            StartCoroutine(waitSecondsLose(1f));
        }
        else
        {
            if (cuttedCount == cuttedToWin)
            {
                StartCoroutine(waitSecondsWin(1f));
            }
        }
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
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

    public void setPlayerDead(bool dead)
    {
        playerDead = dead;
    }

    public bool getPlayerDead()
    {
        return playerDead;
    }
    
    IEnumerator waitSecondsWin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    IEnumerator waitSecondsLose(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

}

