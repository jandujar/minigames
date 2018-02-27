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


	// Use this for initialization
	void Start () {

        if (this.name == "PieceStart1" || this.name == "PieceStart4")
        {
            arrayInOut[0].gameObject.name = "in";
            randomOut = Random.Range(1, 4);
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
	

}
