using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryDash : IMiniGame {
     GameManager game;
    public override void beginGame()
    {
       game.EndGame(MiniGameResult.WIN);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        game = gm;
    }


}
