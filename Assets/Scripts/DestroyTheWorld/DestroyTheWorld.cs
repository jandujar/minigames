using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTheWorld : IMiniGame {

    private GameManager gameManager;
    public Transform canvas;
    public MissileController missile;
    public ParticleSystem explosion;
    private AudioSource source;
    public AudioClip bigExplosion;
    public AudioClip musicBackground;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public override void beginGame()
    {
        Debug.Log(this.ToString() + " game Begin");
        canvas.gameObject.SetActive(true);
        missile.StartGame(gameManager);
        source.PlayOneShot(musicBackground, .5f);
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        this.gameManager = gm;
    }

    public override string ToString()
    {
        return "Destroy The World by DarkJoe";
    }

    public void BigExplosion()
    {
        if (!explosion.isPlaying)
        {
            explosion.Play();
            source.PlayOneShot(bigExplosion, .5f);
            StartCoroutine(ExplosionTime());
        }
        else
        {
            explosion.Stop();
        }
            
    }

    IEnumerator ExplosionTime()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(WinGame());
        BigExplosion();
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }
}
