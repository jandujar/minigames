using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{

    public int points;
    public Text Score;
    public int lives;
    public Text txtLives;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        points = 0;
        lives = 3;
        Score.text = Score.text + points;
        txtLives.text = txtLives.text + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame(IMiniGame.MiniGameResult.LOSE);
        }

        if(points == 770)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }
}
