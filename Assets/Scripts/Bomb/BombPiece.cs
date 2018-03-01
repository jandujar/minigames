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

    // Use this for initialization
    void Start () {

        if (this.name == "PieceStart1" || this.name == "PieceStart4")
        {
            arrayInOut[0].gameObject.name = "in";
            randomOut = Random.Range(1, 1);            
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


    }
    void Update()
    {
        if (this.name == "PieceLvl1_1" || this.name == "PieceLvl1_4")
        {
            for (int i = 0; i < 6; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(2,5);
                    
                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
        if (this.name == "PieceLvl1_2" || this.name == "PieceLvl1_3")
        {
            for (int i = 0; i < 8; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(1,6);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
        if (this.name == "PieceLvl2_1" || this.name == "PieceLvl2_4")
        {
            for (int i = 0; i < 6; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(0, 5);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
        if (this.name == "PieceLvl2_2" || this.name == "PieceLvl2_3")
        {
            for (int i = 0; i < 8; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(1, 2);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
    }
}
