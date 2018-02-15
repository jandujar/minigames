using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour {
    
    public  GameObject[] aNumbers = new GameObject[10];
    int rand = 0;
    string nameID = "Num"; 
    void Start()
    {
        //Init Game    

        rand = (int)Random.Range(0f, 10f);

         aNumbers[rand].gameObject.SetActive(true);

        MathematicalOperations.instance.setNumberInList(nameID + MathematicalOperations.instance.getCountNumbers(), rand);
    }

    
    
}
