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
    public Text shoot_button;
    [SerializeField] private Text txt;
    public float time;
    private float remaining_time;
    public GameManager gm;
    public AudioClip Knife;
    private AudioSource source;
    [SerializeField] private GameObject canvasText;
    public GameObject diana;
    private float diana_rotationSpeed = 60.0f;
    public GameObject win_knife;
    private bool isThrowing = false;
    
    void Start()
    {
        /*anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        animator.SetBool("Shoot", false);*/
        source = GetComponent<AudioSource>();
        remaining_time = time;
    }
    void Update()
    {
        diana.transform.Rotate(Vector3.forward * Time.deltaTime * diana_rotationSpeed);

        ThrowKnife();

    }

    void ThrowKnife()
    {
        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            diana_rotationSpeed = 0f;
            //anim.Play("animacion de lanzar cuchillo");
            Debug.Log("key pressed");
            //animator.SetBool("Shoot", true);
            if (remaining_time <= 6 && remaining_time > 0)
            {
                win_knife.SetActive(true);
                win_knife.GetComponent<Animator>().Play("ShootWinç");
                win_knife.GetComponent<AudioSource>().Play();
            }
            else
            {
                //Animacio lose
                win_knife.SetActive(true);
                win_knife.GetComponent<Animator>().Play("Shoot");
                win_knife.GetComponent<AudioSource>().Play();
            }
        }
    }


    IEnumerator CheckTimeout()
    {
        txt.text = (time).ToString();
        for (int i = 0; i < time; i++)
        {
            remaining_time = time - i;
            txt.text = remaining_time.ToString();
            if (remaining_time <= 6)
            {
                shoot_button.GetComponent<Text>().enabled = true;
                shoot_button.GetComponentInChildren<Image>().enabled = true;
            }

            yield return new WaitForSeconds(1f);

        }
        txt.text = remaining_time.ToString();

        /*if (!InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1))
        {
            gm.EndGame(IMiniGame.MiniGameResult.LOSE);

        }*/

         StartCoroutine(EndLose());
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
