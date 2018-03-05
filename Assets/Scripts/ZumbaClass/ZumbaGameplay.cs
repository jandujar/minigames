using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaGameplay : MonoBehaviour {
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;

    public GameObject winSound;
    public GameObject loseSound;
    public GameObject missSound;

    AudioSource myAudio;

    private bool hasBeenClicked;
    private bool aClicked;
    private bool bClicked;
    private bool xClicked;
    private bool yClicked;
    private int num;

    private int lifes;


    // Use this for initialization
    void Start () {
        lifes = 3;
        hasBeenClicked = false;
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(GameBegins());
    }
	
	// Update is called once per frame
	void Update () {

        if(lifes > 0)
        {
            //CORRECT
            if (Input.GetButtonDown("Fire1") && num == 0)
            {
                a.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                a.SetActive(false);
            }

            if (Input.GetButtonDown("Fire2") && num == 1)
            {
                b.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                b.SetActive(false);
            }

            if (Input.GetButtonDown("Fire3") && num == 2)
            {
                x.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                x.SetActive(false);
            }
            if (Input.GetButtonDown("Fire4") && num == 3)
            {
                y.GetComponent<AudioSource>().Play();
                hasBeenClicked = true;
                y.SetActive(false);
            }

            //WRONG
            if (Input.GetButtonDown("Fire1") && num != 0)
            {
                hasBeenClicked = false;
                Debug.Log("Wrong");
            }
            if (Input.GetButtonDown("Fire2") && num != 1)
            {
                hasBeenClicked = false;
                Debug.Log("Wrong");
            }

            if (Input.GetButtonDown("Fire3") && num != 2)
            {
                hasBeenClicked = false;
                Debug.Log("Wrong");
            }
            if (Input.GetButtonDown("Fire4") && num != 3)
            {
                hasBeenClicked = false;
                Debug.Log("Wrong");
            }
        }
        else
        {
            Debug.Log("LOSER");
            loseSound.GetComponent<AudioSource>().Play();
        }        
    }

    IEnumerator GameBegins()
    {
        yield return new WaitForSeconds(4);
        myAudio.Play();
        for(int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.2f);
            hasBeenClicked = false;
            getOneButton();
            yield return new WaitForSeconds(0.3f);
            PutActiveFalse();
            num = 10;
            returnIfClicked(hasBeenClicked);
        }
        yield return new WaitForSeconds(0.5f);
        if(lifes > 0)
        {
            winSound.GetComponent<AudioSource>().Play();
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

    private void getOneButton()
    {
        num = Random.Range(0, 3);

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

    private void returnIfClicked(bool clicked)
    {
        if (!clicked)
        {
            missSound.GetComponent<AudioSource>().Play();
            lifes--;
        }
    }
}

