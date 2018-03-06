using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackZones : MonoBehaviour {

    [SerializeField]private AttakcsText atkText;
    [SerializeField]private GameObject knife;

    private bool cracked = false;
    private SpriteRenderer render;
    private AudioSource sound;

    void Start () {
        render = gameObject.GetComponent<SpriteRenderer>();
        sound = gameObject.GetComponent<AudioSource>();
        render.enabled = false;
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == knife && !cracked)
        {
            sound.Play();
            render.enabled = true;
            atkText.setTextScore(atkText.getTextScore() + 1);
            cracked = true;
        }
    }
}