using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombienite : IMiniGame {

    private GameManager gameManager;

    public static Zombienite instance = null;
    private InitGame game;
    
    public Text tTimer;
    private float timer = 40f;

    public GameObject player;

    void Awake()
    {
        //Init Zombienite
        Debug.LogError("Change this Script for your own Script");
        if (instance == null)
        {
            instance = this;
            game = GetComponentInChildren<InitGame>();
        }
    }

    void Update()
    {
        //Timer - DeltaTime para ver el tiempo que queda
        if (timer > 0.009)
        {
            timer -= Time.deltaTime;
            tTimer.text = timer.ToString(".00");
        }
        
        if (timer != 0 && player.GetComponent<PlayerZombienite>().GetPlayerIsDead())
        {
            StartCoroutine(waitSecondsLose(1f));
        }else if (timer <= 0.01 && !player.GetComponent<PlayerZombienite>().GetPlayerIsDead())
        {
            StartCoroutine(waitSecondsWin(1f));
            game.endGame();
        }
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        game.init();
    }

    public override string ToString()
    {
        return "Zombienite by Sergi López Dorador";
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
