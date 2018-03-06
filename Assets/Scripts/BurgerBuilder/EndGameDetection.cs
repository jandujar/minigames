using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDetection : MonoBehaviour {

    public IngredientSpawn spawnObject;
    public AudioClip defeatClip;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine(LooseSounds());
        }
    }

    IEnumerator LooseSounds()
    {
        source.PlayOneShot(defeatClip, 1f);
        yield return new WaitForSeconds(1);
        spawnObject.GameOver();
    }
}
