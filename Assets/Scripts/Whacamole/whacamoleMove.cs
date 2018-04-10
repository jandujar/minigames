using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleMove : MonoBehaviour {


    private Animator anim;
    public bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAnimation(bool start)
    {
        if (start)
        {
            anim.SetBool("Move", true);
        }
        else if (!start)
        {
            anim.SetBool("Move", false);
        }
    }



}
