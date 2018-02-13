using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionB : MonoBehaviour
{
    public GitaHiro gameScript;

    void OnTriggerStay(Collider other)
    {
        //B BUTTON
        if ((Input.GetKeyDown(KeyCode.F) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) && other.gameObject.name == "buttonB(Clone)")
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
