using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crupier : MonoBehaviour
{
    public bool StartRep = false;
    private GameManager gameManager;
    //-------------

    bool crupierMove = false;

    int result, nRandom, pointsPlayer, pointsCrupier, cardsPlayer, cardsCrupier;

    public bool wait = false;
    private float waitTime;
    public float maxWaitTime;

    //[SerializeField] Text pointsText;

    public void init(GameManager gm)
    {
        waitTime = maxWaitTime;
        gameManager = gm;
        CrupierAttack();


    }

    // Update is called once per frame
    void Update()
    {
        if (StartRep)
        {
            // "Shift!!"
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)){
                if (!wait){
                MoreCards();
                Pause();
                }
            }

            //"Space!!"
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4))
            {
                crupierMove = true;
            }

            if (crupierMove)
            {
                CrupierAttack();
                Pause();
                if (pointsCrupier >= 17)
                {
                    pointsCompare();
                }
            }


            if (pointsPlayer > 21)
            {
                Lose();
            }

            if (pointsCrupier > 21)
            {
                Win();
            }

            if (wait)
            {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    wait = false;
                    waitTime = maxWaitTime;
                }
            }
            
        }
    }


    private void MoreCards()
    {
        nRandom = (int)Random.Range(1f, 10f);

        if (pointsPlayer <= 10 && nRandom == 1)
            nRandom = 11;
        
        pointsPlayer += nRandom;

        Debug.Log("Payer:  " + pointsPlayer);
        cardsPlayer++;
    }

    private void CrupierAttack(){

        nRandom = (int)Random.Range(1f, 10f);

        if (pointsCrupier <= 10 && nRandom == 1)
            nRandom = 11;
        
        pointsCrupier += nRandom;
        
        
        Debug.Log("Crupier:  " + pointsCrupier);
        cardsCrupier++;
    }

    private void pointsCompare()
    {
        result = pointsPlayer.CompareTo(pointsCrupier);

        switch (result)
        {
            case 1:
                Win();
                break;

            case -1:
                Lose();
                break;

            case 0:
                pointsPlayer = 0;
                cardsPlayer = 0;

                pointsCrupier = 0;
                cardsCrupier = 0;

                crupierMove = false;
                break;

        }
    }

    void Pause()
    {
        wait = true;
    }



    private void Lose() { gameManager.EndGame(IMiniGame.MiniGameResult.LOSE); }
    
    private void Win(){gameManager.EndGame(IMiniGame.MiniGameResult.WIN);}

}
