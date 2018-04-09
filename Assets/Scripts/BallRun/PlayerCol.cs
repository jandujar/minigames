using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCol : MonoBehaviour
{

    [SerializeField]
    public AudioSource winsound;
    private BGmusic bg;
    public GameManager gm;
    private BallRun br;
    public GameObject win;
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
        }
        if(coll.gameObject.tag == "win")
        {
            StartCoroutine(EndWin());
            winsound.Play();
            win.GetComponent<Image>().enabled = true;
            win.GetComponent<Animator>().Play("WinAnim");
            
        }
    } 

  
    public IEnumerator EndLose()
    {
        yield return new WaitForSeconds(0.3f);
        gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    public IEnumerator EndWin()
    {
        yield return new WaitForSeconds(1.6f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }


}

