using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackZones : MonoBehaviour {

    [SerializeField]private AttakcsText atkText;
    [SerializeField]private GameObject knife;

    private bool cracked = false;
    private SpriteRenderer render;

    void Start () {
        render = gameObject.GetComponent<SpriteRenderer>();
        render.enabled = false;
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == knife && !cracked)
        {
            render.enabled = true;
            atkText.setTextScore(atkText.getTextScore() + 1);
            cracked = true;
        }
    }
}