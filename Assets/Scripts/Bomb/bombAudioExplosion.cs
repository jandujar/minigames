using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombAudioExplosion : MonoBehaviour {


    public BombExitpath bomb;


    private void Update()
    {
        if (bomb.lose)
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
