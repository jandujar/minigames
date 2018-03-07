using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTrigger : MonoBehaviour {

    public GameObject Player;

    public AudioClip canShoot;
    private AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Mark>().canShoot && GetComponent<SpriteRenderer>().color.a != 0) {
                source.PlayOneShot(canShoot, .5f);
                other.gameObject.GetComponent<Mark>().puntuation++;
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0);
            }
        }
    }
}
