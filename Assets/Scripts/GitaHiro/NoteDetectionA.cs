using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionA : MonoBehaviour
{
    public GitaHiro gameScript;
    
    void OnTriggerStay(Collider other)
    {
        //A BUTTON
        if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && other.gameObject.name == "A(Clone)")
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
