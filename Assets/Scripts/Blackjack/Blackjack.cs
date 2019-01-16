using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : IMiniGame
{

    public Crupier crupier;

    void Awake()
    {
        //Init BlckJack
        //Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
        crupier.StartRep = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        crupier.init(gm);
    }

    public override string ToString()
    {
        return "BlackJack by Mario_Her/Fer";
    }
}
