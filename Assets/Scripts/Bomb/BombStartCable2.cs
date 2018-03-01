using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable2 : MonoBehaviour {

    public BombStartCable1 cable1;
    public GameObject[] arrayInOut;
    public bool cable3On = false;
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
        Debug.Log("cable2");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 7);
        arrayInOut[randomOut].gameObject.name = "out";
        cable3On = true;
        cable1.cable2On = false;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
