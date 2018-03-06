using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOperators : MonoBehaviour {

    public GameObject[] aOperators = new GameObject[2];
    int rand = 0;
    char op = ' ';

    public void init()
    {
        rand = (int)Random.Range(0f, 2f);
        if (rand == 0)
        {
            op = '-';
        }
        else
        {
            op = '+';
        }

        aOperators[rand].gameObject.SetActive(true);

        MathematicalOperations.instance.setOperatorInList(op);
    }
    
}
