using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable3 : MonoBehaviour {

    public BombStartCable2 cable2;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable4On = false;
    public bool colorSet;
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
        if (!cable2.colorSet && cable2.cable3On)
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    Debug.Log("ok");
                    colorSet = true;
                    arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 2:
                    colorSet = false;
                    Debug.Log("fail");
                    break;
            }
        }
        Debug.Log("cable3");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 7);
        arrayInOut[randomOut].gameObject.name = "out";
        // arraySprite[randomOut].SetActive(true);
        cable4On = true;
        cable2.cable3On = false;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
