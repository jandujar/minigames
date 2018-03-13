using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable1 : MonoBehaviour {

    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable2On;
    private int randomOut;
    private IEnumerator myCorutine;

    void Start()
    {
        myCorutine = StartCable();
        StartCoroutine(myCorutine);      
    }

    IEnumerator StartCable()
    {
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
        randomOut = Random.Range(1,4);
        arrayInOut[randomOut].gameObject.name = "out";
        arrayInOut[randomOut].gameObject.tag = "Finish";
        arraySprite[randomOut].SetActive(true);
        arraySprite[randomOut].name = "red";
        arrayInOut[randomOut].GetComponent<Renderer>().material.color = arrayInOut[0].GetComponent<Renderer>().material.color;
        yield return new WaitForSeconds(0.5f);
        cable2On = true;
        StopCoroutine(myCorutine);
    }
}
