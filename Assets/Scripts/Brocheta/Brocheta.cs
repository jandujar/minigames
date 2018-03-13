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
    public Text myText;
    public GameObject theText;
    int textInt;
    bool actSmoke;
    int rand;
    int lastRand;

    void Start()
    {
        textInt = 15;
        actSmoke = true;
        for(int i = 0; i < area.Length; i++)
        {
            area[rand].SetActive(false);
        }
        StartCoroutine(intLess());
    }
    void Update()
    {
        myText.text = "" + textInt;

        if (stick.GetComponent<stickMovement>().win == true)
        {
            myText.text = "YOU WIN!";
            textInt = 999;
            StartCoroutine(Winner());
        }

        rand = UnityEngine.Random.Range(0, smokes.Length);

        if (actSmoke)
        {
            smokes[rand].Play();
            area[rand].SetActive(true);
            StartCoroutine(startSmoke());
        }
        if(textInt == 0)
        {
            myText.text = "YOU LOST!";
            StartCoroutine(Loser());
        }

    }

    IEnumerator intLess()
    {
        textInt--;
        yield return new WaitForSeconds(1);
        StartCoroutine(intLess());
    }
    IEnumerator Winner(){
        yield return new WaitForSeconds(2);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    IEnumerator Loser()
    {
        yield return new WaitForSeconds(0.3f);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
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
        theText.SetActive(true);
    }

}
