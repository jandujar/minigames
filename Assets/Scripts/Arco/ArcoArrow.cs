using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoArrow : MonoBehaviour {
    bool win = false;
    public Arco game;
    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip diana;
    public AudioClip bg;

    private void Start()
    {

    }

    public void Shooted() {
        StartCoroutine(GameState());
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.eulerAngles = transform.eulerAngles - new Vector3(30, 0, 0);
        GetComponent<AudioSource>().PlayOneShot(hit);
        if (collision.transform.name == "Shield")
        {
            win = true;
            GetComponent<AudioSource>().PlayOneShot(diana);
        }
    }

    IEnumerator GameState() {
        yield return new WaitForSeconds(2.5f);
        game.EndGame(win);
    }

}
