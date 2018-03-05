using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeThrow : IMiniGame
{
    public enum GameState
    {
        Countdown,
        Playing
    }

    public GameState state = GameState.Countdown;
    /*public Animation anim;
    public Animator animator;*/
    [SerializeField] private Text txt;
    public float time;
    private GameManager gm;
    public AudioClip Knife;
    private AudioSource source;
    [SerializeField] private GameObject canvasText;
    private bool isThrowing = false;
    
    void Start()
    {
        /*anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        animator.SetBool("Shoot", false);*/
        source = GetComponent<AudioSource>();

    }
    void Update()
    {


    }
    void ThrowKnife()
    {
        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))

        //anim.Play("animacion de lanzar cuchillo");
        Debug.Log("key pressed");
        //animator.SetBool("Shoot", true);
    }


    IEnumerator CheckTimeout()
    {
        txt.text = (time).ToString();
        for (int i = 0; i < time; i++)
        {
            txt.text = (time - i).ToString();
            yield return new WaitForSeconds(1f);
        }
        txt.text = (0).ToString();

        /*if (!InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            gm.EndGame(IMiniGame.MiniGameResult.LOSE);

        }*/
        if(txt.text == "0")
        {
            StartCoroutine(EndLose());
        }
    }
    IEnumerator CheckEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator EndWin()
    {
        yield return new WaitForSeconds(0.5f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    IEnumerator EndLose()
    {
        yield return new WaitForSeconds(0.5f);
        gm.EndGame(MiniGameResult.LOSE);
    }



    public override void beginGame()
    {
        state = KnifeThrow.GameState.Playing;
        canvasText.SetActive(true);
        StartCoroutine(CheckTimeout());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        state = KnifeThrow.GameState.Countdown;
        canvasText.SetActive(false);
    }

    public override string ToString()
    {
        return "KnifeThrow by Marc";
    }
}
