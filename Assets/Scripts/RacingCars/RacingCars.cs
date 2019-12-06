using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingCars : IMiniGame
{
    public CocheEnemigo coche;

    void Awake()
    {
        //Init Juego
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        coche.enableCar = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        coche.init(gm);
    }

    public override string ToString()
    {
        return "Racing Cars";
    }
}
