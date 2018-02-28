using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPiece : MonoBehaviour {

    //PUBLIC
    public GameObject[] arrayInOut;
    public SpriteRenderer[] arraySpriteInOut;

    //PRIVATE
    private float move;
    private int randomOut;
    private bool openWhile;
    private int prepareRandom;


    // Use this for initialization
    void Start () {

        if (this.name == "PieceStart1" || this.name == "PieceStart4")
        {
            arrayInOut[0].gameObject.name = "in";
            //randomOut = Random.Range(1, 4);
            randomOut = 1;
            arrayInOut[randomOut].gameObject.name = "out";
            arraySpriteInOut[randomOut].enabled = true;
        }
        if (this.name == "PieceStart2" || this.name == "PieceStart3")
        {
            arrayInOut[0].gameObject.name = "in";
            randomOut = Random.Range(1, 7);
            arrayInOut[randomOut].gameObject.name = "out";
            arraySpriteInOut[randomOut].enabled = true;
        }
        if (this.name == "PieceLvl1_1")
        {
            prepareRandom = Random.Range(0, 5);
        }
    }
    void Update()
    {
        if (this.name == "PieceLvl1_1")
        {
            if (arrayInOut[prepareRandom].gameObject.name != "in" && arrayInOut[prepareRandom].gameObject.name != "out")
            {
                arrayInOut[prepareRandom].gameObject.name = "out";
            }
            else if (arrayInOut[prepareRandom].gameObject.name == "in")
            {
                prepareRandom = Random.Range(0, 5);
            }

        }
    }
}
