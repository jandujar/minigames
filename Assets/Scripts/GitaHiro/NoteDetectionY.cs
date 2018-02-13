using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionY : MonoBehaviour
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
        //Y BUTTON
        if ( (Input.GetKeyDown(KeyCode.S)/* || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)*/) && other.gameObject.name == "Y(Clone)")
        {
            gameScript.addScore();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameScript.setEndGame();
    }
}
