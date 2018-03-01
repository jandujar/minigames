using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable3 : MonoBehaviour {

    public BombStartCable2 cable2;
    public GameObject[] arrayInOut;
    public bool cable4On = false;
    private int randomOut;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable2.cable3On)
        {
            myCorutine = StartCable();
            StartCoroutine(myCorutine);
        }
    }

    IEnumerator StartCable()
    {
        Debug.Log("cable3");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 7);
        arrayInOut[randomOut].gameObject.name = "out";
        cable4On = true;
        cable2.cable3On = false;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
