using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private Animation jump;
    public Animator anim; 
    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))                              //we press ANY key during the OnGoing state
        {
            anim.SetTrigger("jumptrigger");
        }
        //anim.ResetTrigger("jumptrigger");
    }
}