using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContollerArkanoid : MonoBehaviour
{
    [SerializeField] private ScriptableMusicClass musicClass;
    private AudioSource[] audioSources;
    [SerializeField] private GameObject ball;
// Start is called before the first frame update
void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();

        audioSources[0].clip = musicClass.audioClips[0];
        audioSources[1].clip = musicClass.audioClips[1];
        audioSources[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<Bolos.BolaController>().activateSound == true)
        {
            audioSources[1].Play();
            ball.GetComponent<Bolos.BolaController>().activateSound = false;
            
        }
    }
}
