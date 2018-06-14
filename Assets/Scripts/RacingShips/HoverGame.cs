using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGame : IMiniGame
{
    private GameManager gameManager;
    [SerializeField]
    private GameObject GameScene;

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        //ball.init(gm); 
    }

    public override string ToString()
    {
        return "Racing Ships by Gerard";
    }

    void Update()
    {
        if (!GameObject.Find("UICanvas").gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf && !GameScene.activeSelf)
        {
            GameScene.SetActive(true);
        }
    }
}
