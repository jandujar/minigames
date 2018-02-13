using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operations : MonoBehaviour {

    private GameManager gameManager;
    private Transform[] aOperations;

    void Awake()
    {
        //Init Game
        Debug.LogError("Change this Script for your own Script");
        aOperations = this.gameObject.GetComponentsInChildren<Transform>();

       /* for (int i = 0; i < aOperations.Length; i++)
        {
            Debug.Log("" + aOperations[i]);
        }
        */
    }
    // Update is called once per frame
    void Update () {
		
	}
}
