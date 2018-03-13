using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Brocheta : IMiniGame
{

    private GameManager gameManager;
    public ParticleSystem[] smokes;
    public GameObject[] area;
    public GameObject stick;
    bool actSmoke;
    int rand;
    int lastRand;



    void Start()
    {
        actSmoke = true;
        for(int i = 0; i < area.Length; i++)
        {
            area[rand].SetActive(false);
        }
    }
    void Update()
    {

        rand = UnityEngine.Random.Range(0, smokes.Length);

        if (actSmoke)
        {
            smokes[rand].Play();
            area[rand].SetActive(true);
            StartCoroutine(startSmoke());
        }

    }
    
    

    IEnumerator startSmoke()
    {
        actSmoke = false;
        lastRand = rand;
        yield return new WaitForSeconds(1.3f);
        smokes[lastRand].Stop();
        area[lastRand].SetActive(false);
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
