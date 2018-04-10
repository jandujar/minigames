using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallRun : IMiniGame
{
    //PUBLIC VARIABLES
    public enum GameState
    {
        Countdown,
        Playing
    }
    public float time;
    public GameObject canvasText;
    public GameState state = GameState.Countdown;
    public GameManager gm;
    public AudioSource bgMusic;
    public GameObject lose;
    public AudioClip loseclip;
    
    //PRIVATE VARIABLES
    [SerializeField] private Text txt;
    private float remaining_time;
    private Movement mv;
    private PlayerCol pc;


    void Start()
    {
        bgMusic = GetComponent<AudioSource>();

    }
    void Update()
    {


    }
    public override void beginGame()
    {
        state = BallRun.GameState.Playing;
        StartCoroutine(CheckTimeout());
        canvasText.SetActive(true);
        bgMusic.Play();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        state = BallRun.GameState.Countdown;
        canvasText.SetActive(false);
    }

    IEnumerator CheckTimeout()
    {
        txt.text = (time).ToString();
        for (int i = 0; i < time; i++)
        {
            remaining_time = time - i;
            txt.text = remaining_time.ToString();

            yield return new WaitForSeconds(1f);
            

        }
        txt.text = remaining_time.ToString();

        StartCoroutine(EndLose());
        pc.Lose();
        //lose.GetComponent<AudioSource>().PlayOneShot(loseclip);



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "win" && remaining_time > 0)
        {
            StartCoroutine(EndWin());
            bgMusic.Stop();
        }
    }
    public IEnumerator CheckEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
    public IEnumerator EndWin()
    {
        yield return new WaitForSeconds(1.5f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    public IEnumerator EndLose()
    {
        yield return new WaitForSeconds(2f);
        gm.EndGame(MiniGameResult.LOSE);
    }
    /*IEnumerator EndLoseLong()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame(MiniGameResult.LOSE);
    }*/


    public override string ToString()
    {
        return "BallRun by Marc Alfonso";
    }
 
}
