using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionY : GitaHiro
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //Y BUTTON
        if ( (Input.GetKeyDown(KeyCode.S) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) && other.gameObject.name == "Y(Clone)")
        {
            addScore();
            Debug.Log("HIT");
            Destroy(other.gameObject);
        }
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
