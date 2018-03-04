using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverGun : MonoBehaviour {

    public GameObject shootEffect;
    public Image shootVFX;
    public AudioSource shootSFX;
    Animator shootAnimator;

	// Use this for initialization
	void Start () {
        shootVFX = shootEffect.GetComponent<Image>();
        shootSFX = GetComponent<AudioSource>();

        shootAnimator = this.GetComponent<Animator>();

        shootVFX.enabled = false;
	}
	
    public IEnumerator shoot()
    {
        shootVFX.enabled = true;
        shootSFX.Play();
        shootAnimator.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(0.05f);
        shootAnimator.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(0.1f);
        shootVFX.enabled = false;
    }

}
