using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuchalipsis : MonoBehaviour
{

    private GameManager gameManager;
    public bool CanLose;
    public bool CanWin;
    //---------------------
    Amuchalipsis_Player Player;

    public void init(GameManager gm)
    {
        gameManager = gm;
        Invoke("StartGame", 4);
        Player = GameObject.FindWithTag("Player").GetComponent<Amuchalipsis_Player>();
    }

    //enpieza el juego
    private void StartGame()
    {
        Player.StartPlay = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Lose()
    {
        if (CanLose)
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    public void Win()
    {
        if (CanWin)
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    /*
     // "control!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            Lose();

        //"alt!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            Win();
     */
}
