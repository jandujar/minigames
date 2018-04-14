using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCol : MonoBehaviour
{

    [SerializeField]
    public AudioSource endSource;
    public AudioClip audioWin, audioLose;
    public GameManager gm;
    public GameObject win;
    public GameObject lose;
    public Movement mv;
    public BallRun br;
    private bool hasLost = false;

    void Start()
    {
        endSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "death")
        {
            Lose();
            StartCoroutine(EndLose());
        }
        if (coll.gameObject.tag == "win")
        {
            Win();
            StartCoroutine(EndWin());
        }
    }

    public IEnumerator EndLose()
    {
        yield return new WaitForSeconds(1.6f);
        gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    public IEnumerator EndWin()
    {
        yield return new WaitForSeconds(1.6f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    public void Win()
    {
        if (!hasLost)
        {
            br.GetComponent<AudioSource>().Stop();
            endSource.PlayOneShot(audioWin);
            win.GetComponent<Image>().enabled = true;
            win.GetComponent<Animator>().Play("win");
            mv.speed = 0;
            mv.jumpForce = 0;
            StopCoroutine(br.CheckTimeout());
        }
    }

    public void Lose()
    {
        hasLost = true;
        br.GetComponent<AudioSource>().Stop();
        endSource.PlayOneShot(audioLose);
        lose.GetComponent<Image>().enabled = true;
        lose.GetComponent<Animator>().Play("lose");
        mv.speed = 0;
        mv.jumpForce = 0;
        StopCoroutine(br.CheckTimeout());
    }
}

