using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CutCarrot : IMiniGame
{

    public GameObject[] carrotParts;
    private GameManager gameManager;
    public Text keyToPress;

    int randomInt;
    int current;
    bool playing = false;
    bool canPress = true;

    IEnumerator SetPress()
    {
        canPress = false;
        yield return new WaitForSeconds(1);

        if (Input.GetButton("Fire1"))
        {
            keyToPress.text = "Fire1";
        }

        canPress = true;
    }

    void MyInput()
    {

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Has pulsado " + keyToPress.text);
            keyToPress.text = "Press " + "Fire1" + " Fast!";
            carrotParts[current].SetActive(false);
            current++;
            StartCoroutine(SetPress());
        }
               
    }

    void Update()
    {
        if (!playing) { return; }

        if(current >= 5) { gameManager.EndGame(IMiniGame.MiniGameResult.WIN); }

        if (canPress && current < carrotParts.Length)
        {
           MyInput();
        }

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        current = 0;
        this.gameManager = gm;
    }

    public override void beginGame()
    {
        playing = true;
        keyToPress.text = "Press Fire1 Fast!";
        MyInput();
    }
}
