using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceClimberController : IMiniGame
{
    [SerializeField]
   private IceClimberPlayer snk;
    public override void beginGame()
    {
         snk.startGame();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        snk.init(gm);
    }
}
