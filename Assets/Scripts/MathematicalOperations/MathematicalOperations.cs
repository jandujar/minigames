using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalOperations : IMiniGame
{
    private GameManager gameManager;
    public GameObject numbers;
    public GameObject operations;
    private Transform[] aNumbers;

    void Awake()
    {
        //Init Game
        Debug.LogError("Change this Script for your own Script");
        

    }

    public override void beginGame()
    {
        //Game Begins
        Debug.Log(this.ToString() + " game Begin");
       /* numbers.SetActive(true);
        operations.SetActive(false);*/
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        //ball.init(gm);
    }

    public override string ToString()
    {
        return "Mathematical Operations by Sergi López";
    }
}
