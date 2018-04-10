using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCol : MonoBehaviour
{

    [SerializeField]
    public AudioSource winsound;
    public AudioSource losesound;
    public GameManager gm;
    private BallRun br;
    public GameObject win;
    public GameObject lose;
    private Movement mv;
    public AudioClip loser;
    

    void Start()
    {
        winsound = GetComponent<AudioSource>();
        

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "death")
        {
            StartCoroutine(EndLose());
            Lose();

        }
        if(coll.gameObject.tag == "win")
        {
            StartCoroutine(EndWin());
            Win();
            
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
        winsound.Play();
        win.GetComponent<Image>().enabled = true;
        win.GetComponent<Animator>().Play("win");
        mv.speed = 0;
        mv.jumpForce = 0;
    }
    
    public void Lose()
    {
        //losesound.PlayOneShot(loser);
        lose.GetComponent<Image>().enabled = true;
        lose.GetComponent<Animator>().Play("lose");
        mv.speed = 0;
        mv.jumpForce = 0;
    }


}

