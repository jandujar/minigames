using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbee : IMiniGame
{

    private GameManager gameManager;
    private AudioSource source;


    public float musicVolume;
    public AudioClip backgroundMusic;
    public dog_src dog;
    void Awake()
    {
        //Init Pong
        Debug.LogError("Change this Script for your own Script");
        source = GetComponent<AudioSource>();
        musicVolume = 0.15f;
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        source.clip = backgroundMusic;
        source.volume = musicVolume;
        source.Play();
        source.loop = true;
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
        dog.init(gm);

    }

    public override string ToString()
    {
        return "Frisby by Miau";
    }

}
