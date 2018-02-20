using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : IMiniGame
{
    private GameManager gameManager;
    public SBSlider slider;


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

