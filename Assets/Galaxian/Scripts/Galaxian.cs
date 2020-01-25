using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Galaxian : IMiniGame
{
    public NaveGalaxian nave;
    GameManager gameManagerInstance;
    void Awake()
    {
        //Init Juego
        nave.alive = true;
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");        
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
