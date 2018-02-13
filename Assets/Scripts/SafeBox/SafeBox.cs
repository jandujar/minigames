using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFuerte : IMiniGame
{



    private GameManager gameManager;
    public Slider slider;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        slider.init(gm);

    }

    public override string ToString()
    {
        return "Caja Fuerte Miau";
    }

}

