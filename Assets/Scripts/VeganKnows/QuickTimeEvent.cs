using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {

    public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    private void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 3);
            Debug.Log(QTEGen);
            CountingDown = 1;
            StartCoroutine(CountDown());

            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[E]";
            }
            if (QTEGen == 2)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[R]";
            }
        }

        if (QTEGen == 1){
            if (Input.anyKeyDown){
                if (Input.GetButton("E_Key")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing ());
                }else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2){
            if (Input.anyKeyDown){
                if (Input.GetButton("R_Key")){
                    CorrectKey = 3;
                    StartCoroutine(KeyPressing());
                }else{
                    CorrectKey = 4;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing(){
        QTEGen = 3;
        Debug.Log(CorrectKey);
        if (CorrectKey == 1){
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS1";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 2)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL2";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 3)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS3";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 4)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL4";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown(){
        yield return new WaitForSeconds(3.5f);
        if (CountingDown == 1){
            QTEGen = 3;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
}
