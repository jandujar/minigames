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
            if ((Input.GetKeyDown(KeyCode.D) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)))
            {
                gameScript.addScore();
                Destroy(gameNote);
                noteDetected = false;
            }
        }
    }
}
