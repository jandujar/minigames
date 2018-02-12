using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionB : GitaHiro
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //B BUTTON
        if ((Input.GetKeyDown(KeyCode.F) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) && other.gameObject.name == "B(Clone)")
        {
            Destroy(other.gameObject);
            addScore(50);
        }
        /*
        else if ((Input.GetKeyDown(KeyCode.F) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) && other.gameObject.name != "B(Clone)")
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
