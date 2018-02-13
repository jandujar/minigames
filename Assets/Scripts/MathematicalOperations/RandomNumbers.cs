using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour {
    
    public  GameObject[] aNumbers = new GameObject[10];
    int rand = 0;
    void Awake()
    {
        //Init Game    

        rand = (int)Random.Range(0f, 10f);
        Debug.Log(rand);

         aNumbers[rand].gameObject.SetActive(true);
    }
    
}
