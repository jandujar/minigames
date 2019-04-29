using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHexagon : MonoBehaviour
{
    
    private GameManager gameManager;
    //--------------------------------------


    public void init(GameManager gm)
    {
        gameManager = gm;
    }
    

    // Update is called once per frame
    void Update()
    {
        // "control!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            Win();

        //"alt!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            Lose();
    }


    private void Lose() { gameManager.EndGame(IMiniGame.MiniGameResult.LOSE); }
    private void Win() { gameManager.EndGame(IMiniGame.MiniGameResult.WIN); }
}
