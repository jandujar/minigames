using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CutCarrot : IMiniGame
{

    public GameObject[] carrotParts;
    public Text keyToPress;

    int randomInt;
    int current;
    bool playing = false;
    bool canPress = true;

    IEnumerator setPress()
    {
        canPress = false;
        yield return new WaitForSeconds(1);
        //randomInt = UnityEngine.Random.Range(0, 3);
        switch (randomInt)
        {
            case 0:
                if (Input.GetButton("Fire1"))
                {
                    keyToPress.text = "Fire1";
                }
                break;

            case 1:
                if (Input.GetButton("Fire2"))
                {
                    keyToPress.text = "Fire2";
                }
                break;

            case 2:
                if (Input.GetButton("Fire3"))
                {
                    keyToPress.text = "Fire3";
                }
                break;
        }

        canPress = true;
    }


    void randomText()
    {
        switch (randomInt)
        {
            case 0:
                    keyToPress.text = "Press " + "Fire1" + " Fast!";
                break;

            case 1:
                if (Input.GetButton("Fire2"))
                    keyToPress.text = "Press " + "Fire2" + " Fast!";

                break;

            case 2:
                if (Input.GetButton("Fire3"))
                    keyToPress.text = "Press " + "Fire3" + " Fast!";

                break;
        }
    }

    void randomizeInput()
    {
        switch (randomInt)
        {
            case 0:
                if (Input.GetButton("Fire1"))
                {
                    Debug.Log("Has pulsado " + keyToPress.text);
                    keyToPress.text = "Press " + "Fire1" + " Fast!";
                    carrotParts[current].SetActive(false);
                    current++;
                    StartCoroutine(setPress());
                }
                break;

            case 1:
                if (Input.GetButton("Fire2"))
                {
                    keyToPress.text = "Press " + "Fire2" + " Fast!";
                    Debug.Log("Has pulsado " + keyToPress.text);
                    carrotParts[current].SetActive(false);
                    current++;
                    StartCoroutine(setPress());
                }
                break;

            case 2:
                if (Input.GetButton("Fire3"))
                {
                    keyToPress.text = "Press " + "Fire3" + " Fast!";
                    Debug.Log("Has pulsado " + keyToPress.text);
                    carrotParts[current].SetActive(false);
                    current++;
                    StartCoroutine(setPress());
                }
                break;
        }
    }

    void Update()
    {
        if (!playing) { return; }

        //if(current >= 5) { EndGame(IMiniGame.MiniGameResult result); }

        if (canPress && current < carrotParts.Length)
        {
            
           randomizeInput();

        }

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        current = 0;
    }

    public override void beginGame()
    {
        playing = true;
        randomInt = UnityEngine.Random.Range(0, 3);
        randomText();
    }
}
