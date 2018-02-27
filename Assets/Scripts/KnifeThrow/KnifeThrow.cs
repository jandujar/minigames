using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : IMiniGame {

    public Animation anim;
    public Animator animator;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        animator.SetBool("Shoot", false);
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void PressSpace()
    {
        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.Stop("Shoot");
            //animator.SetBool("Shoot", true);
        }
        else
        {
            Debug.Log("Error while animation");
        }
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        throw new NotImplementedException();
    }

    public override void beginGame()
    {
        throw new NotImplementedException();
    }
}
