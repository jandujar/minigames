using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHielo : MonoBehaviour
{   

    private bool fase3 = false;
    private bool fase2 = false;

    private Animator anim;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float waitTime2;

    Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(waitTime < Time.time) fase2 = true;
        if(waitTime2 < Time.time) {fase3 = true; rgb.gravityScale = 1; }

        anim.SetBool("Fase2", fase2);
        anim.SetBool("Fase3", fase3);
    }
}
