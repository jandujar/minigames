using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverGun : MonoBehaviour {

    public GameObject shootEffect;
    public Image shootVFX;
    public AudioSource shootSFX;
    Animator shootAnimator;

    public KauboiDueru kauboiGame;

	// Use this for initialization
	void Start () {
        shootVFX = shootEffect.GetComponent<Image>();
        shootSFX = GetComponent<AudioSource>();

        shootAnimator = this.GetComponent<Animator>();

        shootVFX.enabled = false;
	}
	
    public IEnumerator playerShoot()
    {
        kauboiGame.playerHasShoot = true;

        shootSFX.Play();
        shootVFX.enabled = true;
        shootAnimator.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(0.05f);
        shootAnimator.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(0.1f);
        shootVFX.enabled = false;
        //EndGame
        yield return new WaitForSecondsRealtime(1.5f);
        kauboiGame.setEndGame();
    }
    public IEnumerator enemyShoot()
    {
        shootSFX.Play();
        shootVFX.enabled = true;
        shootAnimator.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(0.05f);
        shootAnimator.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(0.1f);
        shootVFX.enabled = false;
        //EndGame
        yield return new WaitForSecondsRealtime(1.5f);
        kauboiGame.setEndGame();
    }

}
