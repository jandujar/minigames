using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContollerArkaoid : MonoBehaviour
{
    [SerializeField] private ScriptableMusicClassArkanoid musicClassArkaoid;
    private AudioSource[] audioSources;
    public bool activateSound;
// Start is called before the first frame update
void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();

        audioSources[0].clip = musicClassArkaoid.audioClips[0];
        audioSources[1].clip = musicClassArkaoid.audioClips[1];
        audioSources[0].Play();

        activateSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       if(activateSound == true)
        {
            audioSources[1].Play();
            activateSound = false;
        }
    }
}
