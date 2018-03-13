using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public TextMesh[] score = new TextMesh[2];
    

    // Update is called once per frame
    void Update () {
        //score[0] --> score //score[1] --> total
        score[0].text = WoodCutter.instance.getCuttedCount().ToString();
        score[1].text = "/" + WoodCutter.instance.getCuttedToWin().ToString();
    }
}
