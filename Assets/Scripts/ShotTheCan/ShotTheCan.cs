using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTheCan : IMiniGame
{
    public GameObject GameScene;
    public GameObject countDown;
    private bool stop = false;
    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
    }

    void Update() {
        if (stop) { return; }
        if (!countDown.gameObject.activeSelf) {
            GameScene.SetActive(true);
            stop = true;
        }
    }

    public override string ToString()
    {
        return "Shot the can by Gerard";
    }
}
