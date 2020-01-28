using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Galaxian : IMiniGame
{
    public NaveGalaxian nave;

    void Awake()
    {
        //Init Juego
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        nave.enableNave = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        nave.init(gm);
    }

    public override string ToString()
    {
        return "Galaxian";
    }
}
