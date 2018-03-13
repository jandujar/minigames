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
    public Text shoot_button;
    [SerializeField] private Text txt;
    public float time;
    private float remaining_time;
    public GameManager gm;
    public AudioClip Knife, Lose;
    private AudioSource bgMusic;
    [SerializeField] private GameObject canvasText;
    public GameObject diana;
    private float diana_rotationSpeed = 60.0f;
    public GameObject win_knife;

    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
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
            if (remaining_time <= 6 && remaining_time > 0)
            {
                win_knife.SetActive(true);
                win_knife.GetComponent<Animator>().Play("ShootWinç");
                win_knife.GetComponent<AudioSource>().Play();
                StartCoroutine(EndWin());
            }
            else
            {
                win_knife.SetActive(true);
                win_knife.GetComponent<Animator>().Play("Shoot");
                win_knife.GetComponent<AudioSource>().Play();
                StartCoroutine(EndLoseLong());
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


        StartCoroutine(EndLose());
    }
    IEnumerator CheckEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator EndWin()
    {
        yield return new WaitForSeconds(2f);
        gm.EndGame(IMiniGame.MiniGameResult.WIN);
    }
    IEnumerator EndLose()
    {
        yield return new WaitForSeconds(0.2f);
        gm.EndGame(MiniGameResult.LOSE);
    }
    IEnumerator EndLoseLong()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame(MiniGameResult.LOSE);
    }



    public override void beginGame()
    {
        state = KnifeThrow.GameState.Playing;
        bgMusic.Play();
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
