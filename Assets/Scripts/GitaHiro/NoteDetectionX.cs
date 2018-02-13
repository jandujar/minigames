using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionX : MonoBehaviour
{
    public GitaHiro gameScript;
    
    void OnTriggerStay(Collider other)
    {
        //X BUTTON
        if ((Input.GetKeyDown(KeyCode.A) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)) && other.gameObject.name == "buttonX(Clone)")
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
