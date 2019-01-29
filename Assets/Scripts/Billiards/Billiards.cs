using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiards : IMiniGame {

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
    }

    public override string ToString()
    {
        return "Billiards by Gerard";
    }
}
