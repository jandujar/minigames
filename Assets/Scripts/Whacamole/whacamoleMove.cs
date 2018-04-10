using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleMove : MonoBehaviour {


    private Animator anim;
    public bool active;
    private Vector3 startPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = this.transform.position;
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

    public void ResetMole()
    {
        anim.SetBool("Move", false);
        this.transform.position = startPos;
    }


}
