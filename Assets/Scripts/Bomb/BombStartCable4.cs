using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable4 : MonoBehaviour {


    public BombStartCable3 cable3;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool colorSet;
    private int randomOut;
    private int enumeratorCount = 0;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable3.cable4On && enumeratorCount == 0)
        {
            myCorutine = StartCable();
            StartCoroutine(myCorutine);
        }
    }

    IEnumerator StartCable()
    {
        enumeratorCount++;
        Debug.Log("cable4");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 4);
        arrayInOut[randomOut].gameObject.name = "out";
        arrayInOut[randomOut].gameObject.tag = "Finish";
        //arraySprite[randomOut].SetActive(true);
        arrayInOut[randomOut].GetComponent<Renderer>().material.color = arrayInOut[0].GetComponent<Renderer>().material.color;
        yield return new WaitForSeconds(1f);
        cable3.cable4On = false;
        StopCoroutine(myCorutine);
    }
}
