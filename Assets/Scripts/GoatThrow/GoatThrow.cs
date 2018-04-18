using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatThrow : IMiniGame
{
    public CabraController cabra;
    public AudioClip music;
    private AudioSource source;
    public override void beginGame()
    {
        source = GetComponent<AudioSource>();
        Debug.Log(this.ToString() + " game Begin");
        cabra.enabled = true;
        source.Play();

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        cabra.init(gm);
    }

    public override string ToString()
    {
        return "GoatThrow by Roger";
    }
}
