using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSegada : IMiniGame
{
    private GameManager gameManager;
    [SerializeField]
    private GameObject NEWcanvas;
    [SerializeField]
    private GameObject DisplayBox;
    [SerializeField]
    private GameObject PassBox;


    public int GameStatus;

    public int RandomResponse;
    public int waitForKey;
    public bool CorrectKey;
    public int countingDown;

    public float timerCD;
    public void Start()
    {
        NEWcanvas.SetActive (false);
        GameStatus = 0;
    }
    public override void beginGame()                                                    //empieza ahora
    {
        //throw new NotImplementedException();
        NEWcanvas.SetActive(true);
        

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)         
    {
        //throw new NotImplementedException();
    }
    void Update()
    {
        switch (GameStatus)                                                     //game control
        {
            case 0:
                PassBox.GetComponent<Text>().text = "";
                break;
            case 1:
                PassBox.GetComponent<Text>().text = "Passed!";
                break;
            case 2:
                PassBox.GetComponent<Text>().text = "FAIL!";
                break;
            default: break;
        }        

        if (waitForKey == 0)
        {
            GameStatus = 0;
            RandomResponse = UnityEngine.Random.Range(1, 4);
            countingDown = 1;
            StartCoroutine(CountDown());

            switch (RandomResponse)
            {
                case 1:
                    waitForKey = 1;
                    DisplayBox.GetComponent<Text>().text = "1";
                    timerCD = 3.0f;
                    break;
                case 2:
                    waitForKey = 2;
                    DisplayBox.GetComponent<Text>().text = "2";
                    timerCD = 2.5f;
                    break;
                case 3:
                    waitForKey = 3;
                    DisplayBox.GetComponent<Text>().text = "3";
                    timerCD = 2.0f;
                    break;
                default:
                    break;
            }            
        }
        
        if (RandomResponse >= 1)
        {
            if (Input.anyKeyDown)
            {
                    CorrectKey = true;
                    StartCoroutine(KeyPressing());
            }
            else { CorrectKey = false; }
        }/*
        if (RandomResponse == 2)
        {
            if (Input.anyKeyDown)
            {
                    CorrectKey = true;
                    StartCoroutine(KeyPressing());
               
            }
        }
        if (RandomResponse == 3)
        {
            if (Input.anyKeyDown)
            {
               
                    CorrectKey = true;
                    StartCoroutine(KeyPressing());
               
            }
        }*/
        
    }


    IEnumerator KeyPressing()
    {
        RandomResponse = 10;
        if (CorrectKey == true)
        {
            countingDown = 2;
            //PassBox.GetComponent<Text>().text = "Passed!";
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
        yield return new WaitForSeconds(timerCD);
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
