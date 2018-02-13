using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QTEcontroller : MonoBehaviour {
    [SerializeField]
    private GameObject DisplayBox;
    [SerializeField]
    private GameObject PassBox;

    public int inputGenerator;
    public int waitForKey;
    public int CorrectKey;
    public int countingDown;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(waitForKey == 0)
        {
            inputGenerator = Random.Range(1, 4);
            countingDown = 1;
            StartCoroutine(CountDown());

            switch (inputGenerator)
            {
                case 1:
                    waitForKey = 1;
                    DisplayBox.GetComponent<Text>().text = "Esquiva joputa";
                    break;
                case 2:
                    waitForKey = 2;
                    DisplayBox.GetComponent<Text>().text = "Esquiva joputa";
                    break;
                case 3:
                    waitForKey = 3;
                    DisplayBox.GetComponent<Text>().text = "Esquiva joputa";
                    break;
                default:
                    break;
            }
        }

        if (inputGenerator==1){
            if (Input.anyKeyDown)
            {
                if (Input.anyKey)
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (inputGenerator == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.anyKey)
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (inputGenerator == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.anyKey)
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

    }


    IEnumerator KeyPressing()
    {
        inputGenerator = 10;
        if (CorrectKey == 1)
        {
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "Passed!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitForKey = 0;
            countingDown = 1;
        }
        if (CorrectKey == 2)
        {
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "Failed!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitForKey = 0;
            countingDown = 1;
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        if (countingDown == 1)
        {
            inputGenerator = 4;
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "Failed!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitForKey = 0;
            countingDown = 1;
        }
    }
    
}
