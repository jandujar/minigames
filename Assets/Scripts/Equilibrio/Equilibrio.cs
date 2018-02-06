using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equilibrio : IMiniGame {
    private GameManager gameManager;
    public BallEquilibrio ball;
    
    void Awake()
    {
        Debug.LogError("Maded by Fabio Scarcella");
    }

   public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        ball.init(gm);
    }

}
