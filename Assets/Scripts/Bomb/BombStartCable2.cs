using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable2 : MonoBehaviour {

    public BombStartCable1 cable1;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable3On = false;
    public bool colorSet;
    private int randomOut;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable1.cable2On)
        {
            myCorutine = StartCable();
            StartCoroutine(myCorutine);
        }
        
    }

    IEnumerator StartCable()
    {
        if (!cable1.colorSet && cable1.cable2On)
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    Debug.Log(cable1.colorSet);
                    colorSet = true;
                    arrayInOut[0].GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 2:
                    colorSet = false;
                    Debug.Log(cable1.colorSet);
                    break;
            }
        }
        Debug.Log("cable2");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 6);
        arrayInOut[randomOut].gameObject.name = "out";
        // arraySprite[randomOut].SetActive(true);
        cable3On = true;
        cable1.cable2On = false;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
