using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumPlayer : BrumCar {

    public bool killed = false;
    public GameObject gameLight;
    public AudioClip backgroundAudio;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    private void Start()
    {
        run = false;
        acceleration = 0.5f;
        deceleration = 0.3f;
    }

    public override void OnTriggerEnterChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerStayChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerExitChild(Collider collider)
    {
        isColliding = false;
    }

    private void Update()
    {
        if (killed) return;
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            run = true;
        }

        if (InputManager.Instance.GetButtonUp(InputManager.MiniGameButtons.BUTTON1))
        {
            run = false;
        }

        if (run)
        {
            speed += acceleration * Time.deltaTime;
        }

        speed -= deceleration * Time.deltaTime;
        if (speed < 0) speed = 0;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - speed);
    }

    public void Kill()
    {
        if (killed) return;
        killed = true;
        gameLight.SetActive(false);
        StartCoroutine(FinishGame(false));
        GetComponent<AudioSource>().PlayOneShot(loseAudio);
    }

    public void Win()
    {
        if (killed) return;
        killed = true;
        StartCoroutine(FinishGame(true));
        GetComponent<AudioSource>().PlayOneShot(winAudio);
    }


    IEnumerator FinishGame(bool win) {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Game").GetComponent<Brum>().EndGame(win);
    }
}
