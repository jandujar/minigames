using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float time = 60f,
            currentTime = 0f;

    [SerializeField]
    SnakeController snake = null;

    GameManager gameManager = null;

    [SerializeField]
    Text    coinsText,
            timerText;
    
    public override void beginGame()
    {
        SpawnCoin();
        snake.StartMoving();
        currentTime = 0f;

        GetComponent<AudioSource>().Play();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gameManager = gm;
        snake.gameManager = gm;
        snake.game = this;
    }
    	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        timerText.text = "Time: " + (time - currentTime).ToString("F");
        coinsText.text = "Coins: " + score.ToString() + "/" + targetScore.ToString();

        if (currentTime >= time)
            gameManager.EndGame(MiniGameResult.LOSE);
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
