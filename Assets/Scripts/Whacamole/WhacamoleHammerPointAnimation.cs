using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleHammerPointAnimation : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Hit", InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1));
    }

}
