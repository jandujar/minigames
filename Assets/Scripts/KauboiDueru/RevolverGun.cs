using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverGun : MonoBehaviour {

    [Header("Guns")]
    public GameObject playerGunObj;
    public GameObject enemyGunObj;
    public Animator playerGunAnim;
    public Animator enemyGunAnim;

    [Header("Effects")]
    public GameObject shootEffect;
    public Image shootVFX;
    public AudioSource shootSFX;
    [Header("Others")]
    public KauboiDueru kauboiGame;


	// Use this for initialization
	void Start () {
        shootVFX = shootEffect.GetComponent<Image>();
        shootVFX.enabled = false;
        shootSFX = GetComponent<AudioSource>();

        playerGunAnim = playerGunObj.GetComponent<Animator>();
        enemyGunAnim = enemyGunObj.GetComponent<Animator>();
	}
	
    public IEnumerator playerShoot()
    {
        kauboiGame.playerHasShoot = true;

        shootSFX.Play();
        shootVFX.enabled = true;
        playerGunAnim.SetBool("Shoot", true);
        enemyGunAnim.SetBool("Death", true);
        yield return new WaitForSecondsRealtime(0.05f);
        playerGunAnim.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(0.1f);
        shootVFX.enabled = false;
        //EndGame
        yield return new WaitForSecondsRealtime(1.5f);
        kauboiGame.setEndGameWin();
    }
    public IEnumerator enemyShoot()
    {
        shootSFX.Play();
        shootVFX.enabled = true;
        enemyGunAnim.SetBool("Shoot", true);
        playerGunAnim.SetBool("Death", true);
        yield return new WaitForSecondsRealtime(0.05f);
        enemyGunAnim.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(0.1f);
        shootVFX.enabled = false;
        //EndGame
        yield return new WaitForSecondsRealtime(1.5f);
        kauboiGame.setEndGame();
    }

}
