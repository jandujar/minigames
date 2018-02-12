using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionA : GitaHiro {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //A BUTTON
        if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && other.gameObject.name == "A(Clone)")
        {
            Destroy(other.gameObject);
            addScore(50);
        }
        /*
        else if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && other.gameObject.name != "A(Clone)")
            Debug.LogError("Fail!");
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adeu siau");
        //Debug.LogError("Fail!");
        setEndGame();
    }
}
