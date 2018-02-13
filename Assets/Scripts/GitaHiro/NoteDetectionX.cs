using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionX : MonoBehaviour
{
    public GitaHiro gameScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        //X BUTTON
        if ((Input.GetKeyDown(KeyCode.A) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)) && other.gameObject.name == "X(Clone)")
        {
            gameScript.addScore();
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
        gameScript.setEndGame();
    }
}
