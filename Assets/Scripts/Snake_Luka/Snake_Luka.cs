using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Luka : IMiniGame
{

    [SerializeField]
    int score = 0,
        targetScore = 20;

    [SerializeField]
    GameObject coin;

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
        //coin.transform.Rotate(new Vector3(45f, 0f, 0f));
    }

    public override void beginGame()
    {
        SpawnCoin();
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

    public void SpawnCoin()
    {
        Vector3 coinPos = new Vector3();
        bool placed = false;
        coinPos.z = 21.46f;

        do {
            float dimensionsX = 31f;
            float dimensionsY = 15f;

            coinPos.x = Mathf.Round(Random.Range(-dimensionsX / 2f, dimensionsX / 2f));
            coinPos.y = Mathf.Round(Random.Range(-dimensionsY / 2f, dimensionsY / 2f));

            placed = !Physics.BoxCast(coinPos, new Vector3(0.5f, 0.5f, 0.5f), Vector3.forward);
        } while (!placed);

        Instantiate(coin, coinPos, coin.transform.rotation);
    }
}
