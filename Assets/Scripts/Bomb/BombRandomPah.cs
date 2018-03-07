using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRandomPah : MonoBehaviour {

    public BombStartCable1 cable1;
    public BombStartCable2 cable2;
    public BombStartCable3 cable3;
    public BombStartCable4 cable4;

    void Awake () {
        switch (Random.Range(0,3))
        {
            case 0:
                cable1.arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                cable2.arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                cable3.arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }
	

}
