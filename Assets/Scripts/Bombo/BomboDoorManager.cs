using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomboDoorManager : MonoBehaviour {

    //PUBLIC
    public GameObject[] arrayInOut;
    public SpriteRenderer[] arraySpriteInOut;

    //PRIVATE
    private float move;
    private int randomOut;


	// Use this for initialization
	void Start () {
        arrayInOut[0].gameObject.name = "in";
        randomOut = Random.Range(1, 7);
        arrayInOut[randomOut].gameObject.name = "out";
        arraySpriteInOut[randomOut].enabled = true;
	}
	

}
