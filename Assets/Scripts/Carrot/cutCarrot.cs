using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CutCarrot : IMiniGame {

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
        canPress = true;
    }

    void Update()
    {
        if(!playing) { return; }

        if (canPress)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Has pulsado " + keyToPress.text);
                carrotParts[current].SetActive(false);
                current++;
                StartCoroutine(setPress());
            }
        }

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        current = 0;
        randomInt = UnityEngine.Random.Range(0, 4);
    }

    public override void beginGame()
    {
        playing = true;
    }
}
