using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallColWithMesh : MonoBehaviour {

    public bool ColDone = false;

    public AudioSource audioBoom;
    

    // Use this for initialization
    void Start () {
        audioBoom = GetComponent<AudioSource>();

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

        if (col.gameObject.tag == "Respawn")
            {

                audioBoom.Play();

            }
    }

   
}
