using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbee : IMiniGame
{

    private GameManager gameManager;
    public dog_src dog;
    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        dog.init(gm);

    }

    public override string ToString()
    {
        return "Frisby by Miau";
    }

}
