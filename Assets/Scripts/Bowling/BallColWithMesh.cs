using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallColWithMesh : MonoBehaviour {

    public bool ColDone = false;

    // Use this for initialization
    void Start () { 


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            ColDone = true;
            Debug.Log("Le dio guey");
        }

    }
}
