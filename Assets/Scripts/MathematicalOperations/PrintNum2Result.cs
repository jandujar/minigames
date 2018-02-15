using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintNum2Result : MonoBehaviour {

    public GameObject[] aNumbers = new GameObject[10];
    private int result = 0;
    private string resultString = " ";


    void Update()
    {
        //Init Game    
        result = MathematicalOperations.instance.getResultOperation();
        resultString = result.ToString();
        for (int i = 0; i < 10; i++)
        {
            if (resultString[0] == '-')
            {
                if (resultString[2] == i.ToString()[0])
                {
                    aNumbers[i].gameObject.SetActive(true);
                    Debug.Log("Número1 mostrado: " + i);
                }
            }else
            {
                if (resultString[1] == i.ToString()[0])
                {
                    aNumbers[i].gameObject.SetActive(true);
                    Debug.Log("Número1 mostrado: " + i);
                }
            }
        }

    }
}
