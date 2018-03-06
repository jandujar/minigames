using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour {
    
    public  GameObject[] aNumbers = new GameObject[10];
    int rand = 0;

    public void init()
    {
        rand = (int)Random.Range(0f, 10f);

        aNumbers[rand].gameObject.SetActive(true);

        MathematicalOperations.instance.setNumberInList(rand);
    }
        
}
