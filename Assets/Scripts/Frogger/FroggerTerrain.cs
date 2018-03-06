using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerTerrain : MonoBehaviour {

    public int initialState = 1;
    public int currentState = 1;
    public int type = 0;

    public void UpdateState() {
        if (type == 1)
        {
            if (currentState <= 0)
            {
                GetComponent<Renderer>().material.color = Color.red;
                currentState = initialState;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.blue;
                currentState--;
            }
        }
        else if (type == 2)
        {
            if (currentState <= 0)
            {
                GetComponent<Renderer>().material.color = Color.blue;
                currentState = initialState;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
                currentState--;
            }
        }
        else if (type == 3) {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
