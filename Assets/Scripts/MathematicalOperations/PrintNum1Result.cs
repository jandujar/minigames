using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintNum1Result: MonoBehaviour {

    public GameObject[] aNumbers = new GameObject[11];
    private int result = 0;
    private string resultString = " ";
  

    void Update()
    {
        //Init Game    
        result = MathematicalOperations.instance.getResultOperation();
        Debug.Log("Resultado: " + result);
        resultString = result.ToString();
        
        Debug.Log("Resultado a String: " + resultString);
        for(int i = 0; i < 11; i++)
        {
            if(resultString[0] != '-')
            {
                if (resultString[0] == i.ToString()[0])
                {
                    aNumbers[i].gameObject.SetActive(true);
                    Debug.Log("Número1 mostrado: " + i);
                }
            }else
            {
                aNumbers[10].gameObject.SetActive(true);
                if (resultString[1] == i.ToString()[0])
                {
                    aNumbers[i].gameObject.SetActive(true);
                    Debug.Log("Número1 mostrado: " + i);
                }
            }
            Debug.Log("Número1: " + resultString[0]);
            Debug.Log("(Int)Número1: " + resultString[0]);
            Debug.Log("(Char)Número1: " + i.ToString()[0]);
            
        }

    }
}
