using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaGameplay : MonoBehaviour {
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;

    AudioSource myAudio;

    private bool aClicked;
    private bool bClicked;
    private bool xClicked;
    private bool yClicked;
    private int num;


    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(GameBegins());
    }
	
	// Update is called once per frame
	void Update () {
        //CORRECT
        if(Input.GetButtonDown("Fire1") && num == 0)
        {
            a.SetActive(false);
            Debug.Log("Yea");
        }

        if (Input.GetButtonDown("Fire2") && num == 1)
        {
            b.SetActive(false);
            Debug.Log("Yea");
        }

        if (Input.GetButtonDown("Fire3") && num == 2)
        {
            x.SetActive(false);
            Debug.Log("Yea");
        }
        if (Input.GetButtonDown("Fire4") && num == 3)
        {
            y.SetActive(false);
            Debug.Log("Yea");
        }
        //WRONG
        if (Input.GetButtonDown("Fire1") && num != 0)
        {
            Debug.Log("Wrong");
        }
        if (Input.GetButtonDown("Fire2") && num != 1)
        {
            Debug.Log("Wrong");
        }

        if (Input.GetButtonDown("Fire3") && num != 2)
        {
            Debug.Log("Wrong");
        }
        if (Input.GetButtonDown("Fire4") && num != 3)
        {
            Debug.Log("Wrong");
        }
    }

    IEnumerator GameBegins()
    {
        yield return new WaitForSeconds(3);
        myAudio.Play();
        for(int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.2f);
            getOneButton();
            yield return new WaitForSeconds(0.3f);
            PutActiveFalse();
            num = 10;
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
}

