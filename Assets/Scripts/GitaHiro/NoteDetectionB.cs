using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionB : MonoBehaviour
{
    public GitaHiro gameScript;
    private bool noteDetected = false;
    private GameObject gameNote;

    void OnTriggerStay(Collider other)
    {
        noteDetected = true;
        gameNote = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        gameScript.setEndGame();
    }
    void Update()
    {
        if(noteDetected==true)
        {
            //B BUTTON
            if ((Input.GetKeyDown(KeyCode.F) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) && gameNote.gameObject.name == "buttonB(Clone)")
            {
                gameScript.addScore();
                Destroy(gameNote);
                noteDetected = false;
            }
        }
    }
}
