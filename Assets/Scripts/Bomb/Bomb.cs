using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : IMiniGame {

    public BombExitpath bomb;



    public override void beginGame()
    {
        //Bomb Begins
        Debug.Log(this.ToString() + " game Begin");
        bomb.enabled = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

    }

    public override string ToString()
    {
        return "Bomb by David Fernandez";
    }
}
