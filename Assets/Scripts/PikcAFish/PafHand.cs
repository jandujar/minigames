using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PafHand : MonoBehaviour
{

    public GameObject hand_win;
    public GameObject hand_lose;
    public PafPickAFish game;
    public AudioClip soundJump;
    public AudioClip soundSplash;
    private bool mDone = false;
    private InputManager inputManager;
    private bool mWin = false;


    void Update()
    {
        if (!mDone && InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            Debug.Log("Space pressed!");
            StartCoroutine(MoveTo(0.5f));
        }
    }

    void Start() {
        StartCoroutine(CheckLose());
        StartCoroutine(PlayJump());
        StartCoroutine(PlaySplash());
    }

    IEnumerator PlayJump()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<AudioSource>().PlayOneShot(soundJump);
    }

    IEnumerator PlaySplash()
    {
        yield return new WaitForSeconds(2.5f);
        if (!mDone)
        {
            GetComponent<AudioSource>().PlayOneShot(soundSplash);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (mDone) return;
        Debug.Log("entered");
        if (coll.gameObject.name == "Fish")
        {
            coll.gameObject.SetActive(false);
            mWin = true;
            FinishMinigame(true);
        }

    }

    public void FinishMinigame(bool result)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        if (result)
        {
            hand_win.SetActive(true);
        }
        else
        {
            hand_lose.SetActive(true);
        }
        StartCoroutine(ChangeGame(result));
    }


    IEnumerator MoveTo(float position_y)
    {
        float speed = 30;
        while (transform.position.y < position_y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        mDone = true;
    }

    IEnumerator CheckLose()
    {
        yield return new WaitForSeconds(4);
        mDone = true;
        if (!mWin) FinishMinigame(false);
    }

    IEnumerator ChangeGame(bool win) {
        yield return new WaitForSeconds(2);
        game.EndGame(win);
    }

}