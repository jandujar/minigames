using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Luka : IMiniGame
{

    [SerializeField]
    int score = 0,
        targetScore = 20;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int TargetScore
    {
        get { return targetScore; }
    }

    [SerializeField]
    float time = 30f,
            currentTime = 0f;

    [SerializeField]
    SnakeController snake = null;

    GameManager gameManager = null;

    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
    }

    public override void beginGame()
    {
        snake.StartMoving();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gameManager = gm;
        snake.gameManager = gm;
        snake.game = this;
    }
    	
	// Update is called once per frame
	void Update () {
		
	}

    public override string ToString()
    {
        return "Snake by Luka";
    }
}
