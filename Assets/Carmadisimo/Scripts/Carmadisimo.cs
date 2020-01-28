using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmadisimo : IMiniGame
{
    [SerializeField] CarMove carMove;
    GameManager gm;
    public override void beginGame()
    {
        carMove.InitGame(gm);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
       this.gm = gm;
    }
}
