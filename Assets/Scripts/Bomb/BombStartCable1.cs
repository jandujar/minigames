using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombStartCable1 : MonoBehaviour {

    public GameObject[] arrayInOut;
    public GameObject[] arraySprite;
    public bool cable2On;
    public bool colorSet;
    private int randomOut;
    private IEnumerator myCorutine;

    void Start()
    {
        myCorutine = StartCable();
        StartCoroutine(myCorutine);      
    }

    IEnumerator StartCable()
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
        Debug.Log("cable1");
        arrayInOut[0].gameObject.name = "in";
        arrayInOut[0].gameObject.tag = "Finish";
        randomOut = 1; // Random.Range(1,4);
        arrayInOut[randomOut].gameObject.name = "out";
        //arraySprite[randomOut].SetActive(true);
 
        cable2On = true;
        StopCoroutine(myCorutine);
        yield return new WaitForSeconds(0.2f);
    }
}
