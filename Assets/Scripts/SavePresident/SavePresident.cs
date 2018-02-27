using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SavePresident : IMiniGame
{

    public GameObject[] carrotParts;
    private GameManager gameManager;
    public Text keyToPress;

    int randomInt;
    int current;
    bool playing = false;
    public AudioSource cut;
    bool canPress = true;

    IEnumerator SetPress()
    {
        canPress = false;
        cut.Play();
        yield return new WaitForSeconds(1);
        canPress = true;
    }

    void MyInput()
    {

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Has pulsado " + keyToPress.text);
            carrotParts[current].SetActive(false);
            current++;
            StartCoroutine(SetPress());
        }

    }

    void Update()
    {
        if (!playing) { return; }

        if (current >= 5) { gameManager.EndGame(IMiniGame.MiniGameResult.WIN); }

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
        keyToPress.text = "Press the magic button fast!";
        MyInput();
    }
}
