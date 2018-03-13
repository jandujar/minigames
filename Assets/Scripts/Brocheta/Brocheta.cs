using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Brocheta : IMiniGame
{

    private GameManager gameManager;
    public ParticleSystem[] smokes;
    public GameObject stick;
    bool actSmoke;
    int rand;
    int lastRand;



    void Start()
    {
        actSmoke = true;
    }
    void Update()
    {

        rand = UnityEngine.Random.Range(0, smokes.Length);

        if (actSmoke)
        {
            smokes[rand].Play();
            StartCoroutine(startSmoke());
        }

    }
    
    

    IEnumerator startSmoke()
    {
        actSmoke = false;
        lastRand = rand;
        yield return new WaitForSeconds(1.3f);
        smokes[lastRand].Stop();
        actSmoke = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override void beginGame()
    {
    }

    //gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    //gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

}
