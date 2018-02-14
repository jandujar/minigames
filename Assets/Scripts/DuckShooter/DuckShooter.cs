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
    public Transform canvas;
    public AudioClip backgroundMusic;
    private AudioSource source;    

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        spawn.init();
        canvas.gameObject.SetActive(true);
        source = GetComponent<AudioSource>();
        source.PlayOneShot(backgroundMusic, 1f);

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        ducksToKill = 0;
        StartCoroutine(LooseTime());
        
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
            canvas.gameObject.SetActive(false);
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
            canvas.gameObject.SetActive(false);
            gameManager.EndGame(MiniGameResult.LOSE);
        }
        

    }

    public override string ToString()
    {
        return "Duck Shooter by DarkJoe";
    }
}
