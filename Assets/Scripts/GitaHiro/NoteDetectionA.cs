using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionA : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //A BUTTON
        if (Input.GetKeyDown(KeyCode.D) && other.gameObject.name == "A(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.D) && other.gameObject.name != "A(Clone)")
            Debug.LogError("Fail!");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adeu siau");
        Debug.LogError("Fail!");
    }
}
