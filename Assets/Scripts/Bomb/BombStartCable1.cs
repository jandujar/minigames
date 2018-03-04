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
        Debug.Log("cable1");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = Random.Range(1,4);
        arrayInOut[randomOut].gameObject.name = "out";
        arraySprite[randomOut].SetActive(true);
        cable2On = true;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
