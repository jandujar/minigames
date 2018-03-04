using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable4 : MonoBehaviour {

    public BombStartCable3 cable3;
    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    private int randomOut;
    private IEnumerator myCorutine;

    void Update()
    {
        if (cable3.cable4On)
        {
            myCorutine = StartCable();
            StartCoroutine(myCorutine);
        }
    }

    IEnumerator StartCable()
    {
        Debug.Log("cable4");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1, 4);
        arrayInOut[randomOut].gameObject.name = "out";
        arraySprite[randomOut].SetActive(true);
        cable3.cable4On = false;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
