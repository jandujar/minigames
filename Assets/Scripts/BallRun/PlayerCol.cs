using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour {

    [SerializeField]public AudioSource winsound;
    private BGmusic bg;

	// Use this for initialization
	void Start () {
        winsound = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "win")
        {
            bg.music.Stop();
            //winsound.Play();
            
            Debug.Log("colisionaste con la winner flag");
        }
    }
}
