using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionY : MonoBehaviour
{
    public GitaHiro gameScript;
    
    void OnTriggerStay(Collider other)
    {
        //Y BUTTON
        if ( (Input.GetKeyDown(KeyCode.S)/* || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)*/) && other.gameObject.name == "buttonY(Clone)")
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
