using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTrigger : MonoBehaviour
{
    public bool gameStop;
    public bool win;
    bool notLost;
    public bool lose;

    void Start()
    {
        gameStop = false;
        win = false;
        notLost = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "enters" && notLost)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                win = true;
            }
        } else if (other.gameObject.name == "lose" && !win)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                notLost = false;
                win = false;
                lose = true;
            }
           
        }
    }
}
