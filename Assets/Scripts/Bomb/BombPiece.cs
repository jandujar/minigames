using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPiece : MonoBehaviour
{

    public BombSpriteDoor test;


    //PUBLIC
    public GameObject[] arrayInOut;

    //PRIVATE
    private int randomOut;

    void Update()
    {
        if (this.name == "PieceStart1" || this.name == "PieceStart4")
        {
            for (int i = 0; i < 5; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(1, 4);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                        arrayInOut[i].GetComponent<BombSpriteDoor>().test[randome].SetActive(true);                                                  
                    }
                }
            }
        }
        if (this.name == "PieceStart2" || this.name == "PieceStart3")
        {
            for (int i = 0; i < 7; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(1, 6);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
        if (this.name == "PieceA")
        {
            for (int i = 0; i < 6; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(2, 5);

                    if (arrayInOut[randome].gameObject.name != "in" && arrayInOut[randome].gameObject.name != "out")
                    {
                        arrayInOut[randome].gameObject.name = "out";
                        arrayInOut[i].gameObject.tag = "Finish";
                    }
                }
            }
        }
        if (this.name == "PieceB")
        {
            for (int i = 0; i < 8; i++)
            {
                if (arrayInOut[i].gameObject.name == "in" && arrayInOut[i].gameObject.tag != "Finish")
                {
                    int randome = Random.Range(2, 7);

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
