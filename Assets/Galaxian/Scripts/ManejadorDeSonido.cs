using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeSonido : Singleton<ManejadorDeSonido>
{
    public AudioClip[] listaSonidos;
    AudioSource[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playShootSound()
    {
        if (!audioSource[0].isPlaying)
        {
            audioSource[0].Play();
        }
    }

    public void playPlayerDeath()
    {
        if (!audioSource[1].isPlaying)
        {
            audioSource[1].Play();
        }
    }
    public void playEnemyDeath()
    {
        if (!audioSource[2].isPlaying)
        {
            audioSource[2].Play();
        }
    }
}
