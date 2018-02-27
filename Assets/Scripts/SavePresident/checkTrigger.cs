using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTrigger : MonoBehaviour
{
    public float Xmove;

    bool triggered;
    bool theBool;
    bool gameStop;
    bool win;

    void Start()
    {
        triggered = false;
        theBool = false;
        gameStop = false;
        win = false;
    }

    void Update()
    {

        if (!gameStop) { 
            if (!theBool)
            {
                transform.position = new Vector3(transform.position.x + Xmove, transform.position.y, transform.position.z);
            }
            else if (theBool)
            {
                transform.position = new Vector3(transform.position.x - Xmove, transform.position.y, transform.position.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "left")
        {
            theBool = false;
        } else if (other.gameObject.name == "right")
        {
            theBool = true;
        }
    }

        void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "interactArea")
        {
            triggered = true;
        }
        
        if (triggered && Input.GetButtonDown("Fire1"))
        {
            win = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "interactArea")
        {
            triggered = false;
        }
    }
}
