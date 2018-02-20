using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainScript : IMiniGame
{

    public int contador;
    public int numero = 50;
    public int rand;
    public float time = 10.0f;
    private GameManager gamemanager;

    void Update()
    {
        time -= Time.deltaTime;
        Debug.Log(time);


        if (time < 0f)
        {

            Debug.Log("You lose");
            gamemanager.EndGame(MiniGameResult.LOSE);

        }

        if (contador == numero)
        {

            Debug.Log("YOU WIN");
            gamemanager.EndGame(MiniGameResult.WIN);

        }
        else
        if (InputManager.Instance.GetButtonDown(0))
        {

            contador = contador + 1;
        }

    }

    public override void beginGame()
    {
        throw new NotImplementedException();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

    }
}

