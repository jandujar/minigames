using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable3 : MonoBehaviour {

    public BombStartCable2 cable2;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable4On = false;
    public bool colorSet;
    private bool exitWhile = false;
    private int randomOut;
    private int enumeratorCount = 0;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable2.cable3On && enumeratorCount == 0)
        {
            myCorutine = StartCable();
            StartCoroutine(myCorutine);
        }
    }

    IEnumerator StartCable()
    {
        enumeratorCount++;
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        arrayInOut[0].GetComponent<Renderer>().material.color = Color.yellow;
        while (!exitWhile)
        {
            randomOut = Random.Range(1, 4);
            {
                arrayInOut[randomOut].gameObject.name = "out";
                arrayInOut[randomOut].gameObject.tag = "Finish";
                arraySprite[randomOut].SetActive(true);
                arraySprite[randomOut].name = "yellow";
                arrayInOut[randomOut].GetComponent<Renderer>().material.color = arrayInOut[0].GetComponent<Renderer>().material.color;
                exitWhile = true;
            }
        }
        yield return new WaitForSeconds(0.5f);
        cable4On = true;
        cable2.cable3On = false;
        StopCoroutine(myCorutine);
    }
}
