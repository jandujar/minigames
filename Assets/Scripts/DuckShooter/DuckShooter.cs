using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShooter : IMiniGame{
    private GameManager gameManager;
    public DuckSpawn spawn;
    private int ducksToKill;
    private int timeToLoose = 0;
    public Transform screenLifes;
    


    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        ducksToKill = 0;
        StartCoroutine(LooseTime());
        spawn.init(gm);
    }

    public void DuckKilled()
    {
        ducksToKill++;
        foreach (Transform child in screenLifes)
        {
            if (child.gameObject.name == ("DuckLifes" + ducksToKill))
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (ducksToKill >= 6)
        {
            gameManager.EndGame(MiniGameResult.WIN);
        }
    }

    IEnumerator LooseTime()
    {
        if (timeToLoose <= 13)
        {
            yield return new WaitForSeconds(1);
            timeToLoose++;
            StartCoroutine(LooseTime());
        }
        else {
            gameManager.EndGame(MiniGameResult.LOSE);
        }
        

    }

    public override string ToString()
    {
        return "Duck Shooter by DarkJoe";
    }
}
