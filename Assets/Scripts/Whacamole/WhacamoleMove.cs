using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhacamoleMove : MonoBehaviour {

    public WhacamoleHoleControl holeControl;
    public WhacamoleScore playerScore;
    public WhacamoleHammerPointAnimation hammerAnim;
    public Animator anim;
    public bool active;
    private Vector3 startPos;
    public bool hit = false;
    public AudioSource[] hammerHit;
    private AudioSource hitMole;
    private AudioSource hitHelmet;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hitMole = hammerHit[0].GetComponent<AudioSource>();
        hitHelmet = hammerHit[1].GetComponent<AudioSource>();
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
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Untagged")
        {
            hitMole.Play();
            anim.speed = 3;
            playerScore.points = playerScore.points + 100;
            if (playerScore.points == 2000)
            {
                StartCoroutine(holeControl.FinishGame("WIN"));
            }
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Finish")
        {
            hitHelmet.Play();
            anim.speed = 0;
            hammerAnim.anim.speed = 0;
            hammerAnim.gameObject.SetActive(false);
            hit = true;
            StartCoroutine(holeControl.FinishGame("LOSE"));
        }

    }

}
