using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBuilder : IMiniGame{
    private GameManager gameManager;
    private int timeToLoose = 0;
    public IngredientSpawn spawn;
    public Transform canvas;
    public AudioClip backgroundMusic;
    private AudioSource source;    

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        canvas.gameObject.SetActive(true);
        source = GetComponent<AudioSource>();
        source.PlayOneShot(backgroundMusic, 1f);

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        spawn.StartSpawn();
        StartCoroutine(LooseTime());

        
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
        return "Burger Builder by DarkJoe";
    }
}
