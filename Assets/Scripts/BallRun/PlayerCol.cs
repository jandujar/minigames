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
    // Use this for initialization
    void Start()
    {
        winsound = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "death")
        {
            StartCoroutine(EndLose());
            losesound.Play();
            lose.GetComponent<Image>().enabled = true;
            lose.GetComponent<Animator>().Play("LoseAnim");
            mv.speed = 0;
            mv.jumpForce = 0;
        }
        if(coll.gameObject.tag == "win")
        {
            StartCoroutine(EndWin());
            winsound.Play();
            win.GetComponent<Image>().enabled = true;
            win.GetComponent<Animator>().Play("WinAnim");
            mv.speed = 0;
            mv.jumpForce = 0;
            
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


}

