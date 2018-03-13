using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaGameplay : MonoBehaviour {

    private GameManager gameManager;
  
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;

    public GameObject winSound;
    public GameObject loseSound;
    public GameObject missSound;
    public GameObject ggSound;

    private bool hasBeenClicked;
    private bool aClicked;
    private bool bClicked;
    private bool xClicked;
    private bool yClicked;
    private int num;

    private int lifes;

    private IEnumerator myCorutine;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    // Use this for initialization
    void Start () {
        lifes = 3;
        hasBeenClicked = false;
        myCorutine = GameBegins();
        StartCoroutine(myCorutine);
    }
	
	// Update is called once per frame
	void Update () {

        if(lifes > 0)
        {
            //CORRECT
            if (Input.GetButtonDown("Fire1") && num == 0)
            {
                ggSound.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                a.SetActive(false);
            }

            if (Input.GetButtonDown("Fire2") && num == 1)
            {
                ggSound.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                b.SetActive(false);
            }

            if (Input.GetButtonDown("Fire3") && num == 2)
            {
                ggSound.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                x.SetActive(false);
            }
            if (Input.GetButtonDown("Fire4") && num == 3)
            {
                ggSound.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                y.SetActive(false);
            }

            //WRONG
            if (Input.GetButtonDown("Fire1") && num != 0)
            {
                hasBeenClicked = false;
            }
            if (Input.GetButtonDown("Fire2") && num != 1)
            {
                hasBeenClicked = false;
            }

            if (Input.GetButtonDown("Fire3") && num != 2)
            {
                hasBeenClicked = false;
            }
            if (Input.GetButtonDown("Fire4") && num != 3)
            {
                hasBeenClicked = false;
            }
        }       
    }

    IEnumerator GameBegins()
    {
        yield return new WaitForSeconds(4);
        for(int i = 0; i < 12; i++)
        {
            
            yield return new WaitForSeconds(0.1f);
            hasBeenClicked = false;
            GetOneButton();
            yield return new WaitForSeconds(0.7f);
            PutActiveFalse();
            num = 10;
            ReturnIfClicked(hasBeenClicked);
            CheckLifes();
            if (CheckLifes())
            {
                StopCoroutine(myCorutine);
            }
        }
        yield return new WaitForSeconds(0.5f);
        if(lifes > 0)
        {
            winSound.SetActive(true);
            winSound.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }

    }

    private void PutActiveFalse()
    {
        switch (num)
        {
            case 0:
                a.SetActive(false);
                break;
            case 1:
                b.SetActive(false);
                break;
            case 2:
                x.SetActive(false);
                break;
            case 3:
                y.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void GetOneButton()
    {
        num = Random.Range(0, 4);

        switch (num)
        {
            case 0:
                a.SetActive(true);
                break;
            case 1:
                b.SetActive(true);
                break;
            case 2:
                x.SetActive(true);
                break;
            case 3:
                y.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void ReturnIfClicked(bool clicked)
    {
        if (!clicked)
        {
            missSound.GetComponent<AudioSource>().Play();
            lifes--;
        }
    }
    
    private bool CheckLifes()
    {
        if(lifes <= 0)
        {
            loseSound.SetActive(true);
            loseSound.GetComponent<AudioSource>().Play();
            StartCoroutine(LoseCorutine());
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator LoseCorutine()
    {
        yield return new WaitForSeconds(3);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
}

