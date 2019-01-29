using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpGameEng : IMiniGame
{

    [SerializeField] float speed = 2;
    [SerializeField] GameObject playerCube;
    [SerializeField] GameObject coinList;
    [SerializeField] int Lifes;
    [SerializeField] GameManager gameManagerInstance;
    [SerializeField] TextMesh lifetext;

    //AUDIO
    [SerializeField] AudioSource[] Audios;

    //KILLING
    private bool killed = false;
    private float tempcounter = 0.4f;
    public bool hittedOnetime = false;
    private bool stophits = false;

    //SAFEZONES
    public bool WIN = false;
    public Vector3 lastSafePlace;

    //BoolStart
    public bool startOfGame = false;

    




    public override void beginGame()
    {
        Audios[0].Play();
        startOfGame = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {

        gm = gameManagerInstance;

    }

    // Start is called before the first frame update
    void Start()
    {
        Lifes = 3;
        if (playerCube == null) playerCube = GameObject.Find("Player");
        lastSafePlace = playerCube.transform.position;

        SetTextLife();
    }

    // Update is called once per frame
    void Update()
    {


        if (startOfGame)
        {
            Vector3 pos = playerCube.transform.position;

            if (!killed)
            {

                if (InputManager.Instance.GetAxisVertical() > 0)
                {

                    pos.y += speed * Time.deltaTime * InputManager.Instance.GetAxisVertical();
                    //playerCube.transform.Rotate(10, 0,0);


                }
                else if (InputManager.Instance.GetAxisVertical() < 0)
                {
                    pos.y += speed * Time.deltaTime * InputManager.Instance.GetAxisVertical();

                    //playerCube.transform.Rotate(-10, 0, 0);

                }

                if (InputManager.Instance.GetAxisHorizontal() > 0)
                {
                    pos.x += speed * Time.deltaTime * InputManager.Instance.GetAxisHorizontal();
                    //playerCube.transform.Rotate(0, -10, 0);
                }
                else if (InputManager.Instance.GetAxisHorizontal() < 0)
                {
                    pos.x += speed * Time.deltaTime * InputManager.Instance.GetAxisHorizontal();
                    //playerCube.transform.Rotate(0, 10, 0);
                }
                playerCube.transform.position = pos;


            }
        }

        //KILLED

        if (hittedOnetime)
        {
            if (!stophits)
            {
                Time.timeScale = 0.4f;
                stophits = true;
            }
        }

        if (Time.timeScale <= 0.4f && Time.timeScale > 0)
        {

            killed = true;
            Audios[0].Pause();
            Audios[1].Play();
            tempcounter -= 0.01f;
            if (tempcounter <= 0) tempcounter = 0;
            Time.timeScale = tempcounter;
        }
        else if (Time.timeScale == 0)
        {
            tempcounter += 0.02f;

            if (tempcounter >= 1f)
            {

                Lifes--;

                if(Lifes <= 0)
                {
                    gameManagerInstance.EndGame(MiniGameResult.LOSE);
                }

                playerCube.transform.position = lastSafePlace;
                Time.timeScale = 1;
                stophits = false;
                hittedOnetime = false;
                killed = false;
                tempcounter = 0.4f;
                Audios[0].UnPause();

                SetTextLife();

            }


           
        }
        if (WIN)
        {
            gameManagerInstance.EndGame(MiniGameResult.WIN);
            return;
        }
    }

    private void SetTextLife()
    {

        lifetext.text = Lifes.ToString();


    }
}
