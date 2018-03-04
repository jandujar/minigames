using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbaGameplay : MonoBehaviour {
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;

    public AudioClip music;
    AudioSource myAudio;

    private bool hasBeenClicked;
    private int num;


    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
        hasBeenClicked = false;
        StartCoroutine(GameBegins());
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator GameBegins()
    {
        yield return new WaitForSeconds(3);
        myAudio.Play();
        for(int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.2f);
            getOneButton();
            yield return new WaitForSeconds(0.5f);
            PutActiveFalse();
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
        Debug.Log(num);

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

