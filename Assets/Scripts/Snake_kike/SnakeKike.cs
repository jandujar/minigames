using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeKike : IMiniGame
{

   [SerializeField]
   private SnakeControllerKike snk;
    public override void beginGame()
    {
         snk.startGame();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        snk.init(gm);
    }
}