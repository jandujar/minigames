using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
    private Vector3 origen;
    public Transform destination;
    // Use this for initialization
    void Awake()
    {

        origen = transform.position;

    }


    void Update()
    {
        if (InputManager.Instance.GetButtonDown(0))
        {


            transform.position = destination.position;

        }
        else
        {
            transform.position = origen;
        }
    }


}