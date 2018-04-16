using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	public GameObject manageShooting;
	private SpriteRenderer spr;
	private int randSpr;
	private bool colision;
	private AudioSource source;
	public Sprite[] sprEnemy;
	public Sprite[] sprAlly;
	public AudioClip[] scream;
	public Sprite nothing;

	public void Awake(){
		spr = this.GetComponent<SpriteRenderer> ();
		source = this.GetComponent<AudioSource> ();
	}

	public void moveUp(bool valid, float delay){
		colision = false;

		randSpr = Random.Range (0, sprAlly.Length);
		if (!valid) {
			spr.sprite = sprAlly [randSpr];
			source.PlayOneShot (scream[0], 0.5f);
		} else {
			spr.sprite = sprEnemy [randSpr];
			source.PlayOneShot (scream[1], 0.5f);
		}

		StartCoroutine (ObjectiveDesapear (delay, valid));
	}

	private IEnumerator ObjectiveDesapear(float delay, bool valid){
		yield return new WaitForSecondsRealtime (delay);
		//this.transform.Rotate (-90, 0, 0, Space.Self);
		spr.sprite = nothing;

		//valid = false;

		if (valid) {
			if (colision) {
				//WIN
				manageShooting.GetComponent<ShootingManager>().endGame(IMiniGame.MiniGameResult.WIN);
			} else {
				//LOSE
				manageShooting.GetComponent<ShootingManager>().endGame(IMiniGame.MiniGameResult.LOSE);
			}
		} else {
			if (colision) {
				//LOSE
				manageShooting.GetComponent<ShootingManager>().endGame(IMiniGame.MiniGameResult.LOSE);
			} else {
				//WIN
				manageShooting.GetComponent<ShootingManager> ().InitGame ();
			}

		}
	}

	private void OnCollisionEnter(Collision other){
		if (other.collider.name == "Bullet") {
			colision = true;
		}
	}
}
