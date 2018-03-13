using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogger : IMiniGame
{
    private GameManager gameManager;
    public GameObject game;
    void Awake()
    {

    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        game.SetActive(true);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
        else
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }

    public override string ToString()
    {
        return "Frogger by Ramon Cano";
    }
}

