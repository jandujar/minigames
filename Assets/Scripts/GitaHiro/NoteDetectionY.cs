using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionY : MonoBehaviour
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
        if(noteDetected == true)
        {
            //Y BUTTON
            if ((Input.GetKeyDown(KeyCode.S) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) && gameNote.gameObject.name == "buttonY(Clone)")
            {
                gameScript.addScore();
                Destroy(gameNote);
                noteDetected = false;
            }
        }
    }
}
