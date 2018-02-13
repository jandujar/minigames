using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetectionA : MonoBehaviour
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
        if (noteDetected == true)
        {
            //A BUTTON
            if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && gameNote.gameObject.name == "buttonA(Clone)")
            {
                gameScript.addScore();
                Destroy(gameNote);
                noteDetected = false;
            }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && gameNote.gameObject.name != "buttonA(Clone)")
            {
                gameScript.setEndGame();
            }
        }
    }
}
