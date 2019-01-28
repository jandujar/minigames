using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SonidosFondo;
    public float TimeSound1;

    private float timesound1;

    // Start is called before the first frame update
    void Start()
    {
        timesound1 = TimeSound1;
    }

    // Update is called once per frame
    void Update()
    {
        timesound1 -= Time.deltaTime;
        if(timesound1 < 0)
        {
            SonidosFondo.Play();
        }
    }
}
