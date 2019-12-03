using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingCars : IMiniGame
{
    public Ball ball;

    void Awake()
    {
        //Init Pong

    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        ball.enableBall = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        ball.init(gm);
    }

    public override string ToString()
    {
        return "Pong by Jandujar";
    }
}
