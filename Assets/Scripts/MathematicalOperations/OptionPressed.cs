using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPressed : MonoBehaviour {

    private SpriteRenderer sprite;

	// Use this for initialization
	void Awake () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.enabled = false;
    }
	
	public void setEnableSprite(bool enable)
    {
        sprite.enabled = enable;
        StartCoroutine(waitSeconds(0.5f));
    }
     
    IEnumerator waitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sprite.enabled = false;
    }
}
