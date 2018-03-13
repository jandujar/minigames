using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable2 : MonoBehaviour {

    public BombStartCable1 cable1;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable3On = false;
    private bool exitWhile = false;
    private int randomOut;
    private int enumeratorCount = 0;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable1.cable2On && enumeratorCount == 0)
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
        arrayInOut[0].GetComponent<Renderer>().material.color = Color.blue;
        while (!exitWhile){
            randomOut = Random.Range(1, 6);
            if (arrayInOut[randomOut].gameObject.tag != "Finish" )
            {
                arrayInOut[randomOut].gameObject.name = "out";
                arrayInOut[randomOut].gameObject.tag = "Finish";
                arraySprite[randomOut].SetActive(true);
                arraySprite[randomOut].name = "blue";
                arrayInOut[randomOut].GetComponent<Renderer>().material.color = arrayInOut[0].GetComponent<Renderer>().material.color;
                exitWhile = true;
            }
        }
        yield return new WaitForSeconds(0.5f);
        cable3On = true;
        cable1.cable2On = false;
        StopCoroutine(myCorutine);
    }
}
