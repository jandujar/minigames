using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : IMiniGame
{
    public GameManager gameManager;
    public GameObject game;

    public override void beginGame()
    {
    
       //game.EndGame(MiniGameResult.WIN);
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

}
