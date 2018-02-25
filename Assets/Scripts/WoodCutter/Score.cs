using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private TextMesh[] score = new TextMesh[2];

    void Awake()
    {
        for(int i = 0; i < 2; i++)
        {
            //i = 0 -> score // i = 1 -> total 
            score[i] = GetComponentInChildren<TextMesh>();
        }    
    }

    // Update is called once per frame
    void Update () {
        score[0].text = WoodCutter.instance.getCuttedCount().ToString();
        score[1].text = "/" + WoodCutter.instance.getCuttedToWin().ToString();
    }
}
