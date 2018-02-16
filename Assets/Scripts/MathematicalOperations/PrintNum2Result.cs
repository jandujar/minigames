using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintNum2Result : MonoBehaviour {

    public GameObject[] aNumbers = new GameObject[10];
    private int result = 0;
    private string resultString = " ";
    public bool printNum2ResultEnabled = false;
    private bool printNum2ResultFinished = false;


    void Update()
    {
        //Init Game    
        if (printNum2ResultEnabled)
        {
            result = MathematicalOperations.instance.getResultOperation();
            resultString = result.ToString();
            for (int i = 0; i < 10; i++)
            {
                if (resultString[0] != '-')
                {
                    if (resultString[1] == i.ToString()[0])
                    {
                        aNumbers[i].gameObject.SetActive(true);
                        Debug.Log("Número1 mostrado: " + i);
                        break;
                    }
                }
                else
                {
                    if (resultString[2] == i.ToString()[0])
                    {
                        aNumbers[i].gameObject.SetActive(true);
                        Debug.Log("Número1 mostrado: " + i);
                        break;
                    }
                }
            }

            printNum2ResultFinished = true;

        }
    }

    public bool getPrintNum2ResultFinished()
    {
        return printNum2ResultFinished;
    }

}

