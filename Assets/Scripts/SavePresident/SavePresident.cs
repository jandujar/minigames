using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SavePresident : IMiniGame
{

    public GameObject agent;
    public GameObject agentMiss;
    public GameObject aim;
    public GameObject president;
    private GameManager gameManager;
    public GameObject win;
    bool notLose;
    public Text myText;
    public int countdown;
    bool startCountdown;
    bool stopCountdown;
    public AudioSource scream;
    public AudioSource bullet;
    bool cantWin;
    bool winPlaying;
    bool losePlaying;
    bool moveAgent;
    bool canPlay;
    bool toWin;
    public ParticleSystem fx;

    void Start()
    {
        notLose = false;
        moveAgent = false;
        win.SetActive(false);
        cantWin = false;
        losePlaying = false;
        winPlaying = false;
    }

    IEnumerator lost()
    {
        yield return new WaitForSeconds(2);
        president.SetActive(false);
        bullet.Play();
        fx.Play();
        yield return new WaitForSeconds(0.5f);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

    }

    IEnumerator winner()
    {
        yield return new WaitForSeconds(2);
        bullet.Play();
        fx.Play();
        win.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);

    }

    void Update()
    {
        toWin = aim.GetComponent<checkTrigger>().win;
        if (canPlay) {

            if (toWin && Input.GetButton("Fire1") && !cantWin && !winPlaying)
            {
                winPlaying = true;
                notLose = true;
                agent.GetComponent<Animation>().Play();
                scream.Play();
                StartCoroutine(winner());
            }

            if (!toWin && Input.GetButton("Fire1") && !notLose && !losePlaying)
            {
                losePlaying = true;
                cantWin = true;
                agentMiss.GetComponent<Animation>().Play();
                scream.Play();
                StartCoroutine(lost());
            }

        }
    }

    IEnumerator Winner()
    {
        moveAgent = true;
        yield return new WaitForSeconds(3);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override void beginGame()
    {
        aim.GetComponent<Animation>().Play();
        canPlay = true;
    }
}
