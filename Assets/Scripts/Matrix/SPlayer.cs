using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviour
{

    public GameManager gm;
    private Animator anim;
    private AudioSource audio;
    public bool beginPlay = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        beginPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!beginPlay)
        {
            return;
        }

        Vector3 movement = new Vector3();
        movement.y = -Input.GetAxis("Horizontal");
        movement.x = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", movement.magnitude);

        RaycastHit2D rc = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude, LayerMask.NameToLayer("Default"), 1.0f);

        if (rc.collider != null && rc.collider.tag == "GameController")
        {
            movement = Vector3.zero;
        }

        transform.Translate(movement * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Finish")
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        Time.timeScale = 0.1f;
        audio.Play();
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1.0f;
        gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
}
