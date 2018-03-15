using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cans : MonoBehaviour {

    [SerializeField]
    private float power;

    [SerializeField]
    private Text myText;

    private int canNumber = 0;

    public GameObject Player;

    private GameManager Gm;
    // Use this for initialization
    void Start () {
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("LaunchCans", 0, 2.5f);
	}

    void LaunchCans() {


        if (canNumber >= transform.childCount) { return; }

        myText.text = "CAN NUMBER " + (canNumber+1) + " GOING!!!";
        StartCoroutine(Launch(transform.GetChild(canNumber).gameObject));

        canNumber++;
    }
    private IEnumerator Launch(GameObject can)
    {
        yield return new WaitForSecondsRealtime(.75f);
        //Debug.Log("Power: " + power);
        can.GetComponent<Rigidbody>().AddForce(Vector3.up * power);
        can.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * power);
        //power = 0f;

        if (canNumber == 3) {
            yield return new WaitForSecondsRealtime(3);
            Player.GetComponent<Mark>().vely = 0;
            Player.GetComponent<Mark>().enableShot = false;
            if (Player.GetComponent<Mark>().puntuation < 3) {
                myText.text = "LOOSE";
                yield return new WaitForSecondsRealtime(2);
                Gm.EndGame(IMiniGame.MiniGameResult.LOSE);
            }
        }
    }
}
