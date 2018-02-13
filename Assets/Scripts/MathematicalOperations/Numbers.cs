using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour {

   // private GameManager gameManager;
    public  Transform[] aNumbers;

    void Awake()
    {
        //Init Game
        aNumbers = this.gameObject.GetComponentsInChildren<Transform>();

      /* for (int i = 0; i < aNumbers.Length; i++)
        {
            Debug.Log("" + aNumbers[i]);
        }*/

    }

    // Update is called once per frame
    void Update () {
		
	}
}
