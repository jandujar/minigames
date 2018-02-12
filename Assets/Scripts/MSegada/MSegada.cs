using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSegada : IMiniGame
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject NEWcanvas;
    [SerializeField]
    private GameObject DisplayBox;
    [SerializeField]
    private GameObject PassBox;


    public int GameStatus;

    public int RandomResponse;      //gets a random value to determinate the difficulty 
    public int waitForKey;          //determinates the state
    public bool CorrectKey;         //win or lose
    public int countingDown;

    public float timerCD;
    public void Start()
    {
        //countingDown = 0;
        NEWcanvas.SetActive (false);
        //GameStatus = 0;
        

    }
    public override void beginGame()                                                    //empieza ahora
    {
        //throw new NotImplementedException();
        NEWcanvas.SetActive(true);
        Invoke("GameFlow", 5);          
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)         
    {
        //throw new NotImplementedException();
        //StartCoroutine(WaitGame());
        gameManager = gm;
       
    }

    public void GameFlow()
    {
        Debug.Log("finally");
       
        TimerToAction();
    }

    public void checkGameStatus()
    {
        
        switch (GameStatus)                                                     //game control
        {
            case 0:
                PassBox.GetComponent<Text>().text = "Wait...";
                break;
            case 1:
                PassBox.GetComponent<Text>().text = "Passed!";
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
                break;
            case 2:
                Debug.Log("FAIL");
                PassBox.GetComponent<Text>().text = "FAIL!";
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
                break;
            default: break;
        }        
    }

    public void TimerToAction()
    {
        if (waitForKey == 0)
        {
            GameStatus = 0;
            RandomResponse = UnityEngine.Random.Range(1, 4);
            countingDown = 1;
            StartCoroutine(CountDown());
            compareResponse();
        }
        checkGameStatus();
    } 

    void compareResponse()              
    {
    switch (RandomResponse)
            {
                case 1:
                    waitForKey = 1;
                    DisplayBox.GetComponent<Text>().text = "Press Any key!   1";
                    timerCD = 3.0f;                             
                    break;                                      
                case 2:
                    waitForKey = 2;                                
                    DisplayBox.GetComponent<Text>().text = "Press Any key!   2";
                    timerCD = 2.5f;                              
                    break;                                       
                case 3:
                    waitForKey = 3;                                 
                    DisplayBox.GetComponent<Text>().text = "Press Any key!   3";
                    timerCD = 2.0f;
                    break;
                default:
                    break;
            }           
    }
    void Update()                                   
    {       
        checkGameStatus();
        if (RandomResponse != 0)
        {
        if (Input.anyKeyDown)
            {
                CorrectKey = true;
                StartCoroutine(KeyPressing());
            }
        }
    }


    IEnumerator KeyPressing()
    {
        //yield return new WaitForSeconds(3.0f);
        RandomResponse = 10;
        if (CorrectKey == true)
        {
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "Passed!";
            GameStatus = 1;
            yield return new WaitForSeconds(1.5f);
            //CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitForKey = 0;
            countingDown = 1;
        }
        
        GameStatus = 0;
    }
    IEnumerator CountDown()
    {
        //yield return new WaitForSeconds(timerCD);
        if (countingDown == 1)
        {
            RandomResponse = 4;
            countingDown = 2;
            // PassBox.GetComponent<Text>().text = "Failed!";
            GameStatus = 2;
            yield return new WaitForSeconds(1.5f);
            //CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitForKey = 0;
            countingDown = 1;
        }
        GameStatus = 0;
    }
}
