using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : IMiniGame {

    private GameManager gameManager;
    public BoxingPlayerController player;
    public BoxingEnemyController enemy;
    public BoxingCanKo button;


    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        player.enabled = true;
        enemy.enabled = true;
        button.enabled = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        player.init(gm);
        enemy.init(gm);
        button.init(gm);
    }

    public override string ToString()
    {
        return "Boxing by David Fernandez";
    }
}
