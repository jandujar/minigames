using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour {

    public AudioSource music;

	void Start ()
    {
        music = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        music.Play();
	}
}
