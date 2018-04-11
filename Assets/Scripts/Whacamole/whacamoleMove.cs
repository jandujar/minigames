using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleMove : MonoBehaviour {

    public WhacamoleHammerPointAnimation hammerAnim;
    public Animator anim;
    public bool active;
    private Vector3 startPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = transform.position;
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.speed = 3;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Finish")
        {
            anim.speed = 0;
            hammerAnim.anim.speed = 0;
        }

    }

}
