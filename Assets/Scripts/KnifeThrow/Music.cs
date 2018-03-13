using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public AudioSource music;
	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        music.Play();
		
	}
}
