using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public AudioClip Jump;
    AudioSource fuenteAudio;

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800f);
            fuenteAudio.clip = Jump;
            fuenteAudio.Play();
        }

    }
}
