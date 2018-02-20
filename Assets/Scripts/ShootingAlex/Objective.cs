using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	public GameObject manageShooting;
	private Material mat;
	private int randTex;
	private bool colision;
	private bool target;
	private Vector3 startRotation;
	private AudioSource source;
	public Texture[] texEnemy;
	public Texture[] texAlly;
	public AudioClip[] scream;

	public void Awake(){
		mat = this.GetComponentInChildren<MeshRenderer> ().materials [0];
		startRotation = this.transform.rotation.eulerAngles;
		source = this.GetComponent<AudioSource> ();
		//target = false;
	}

	public void moveUp(bool valid, float delay){
		//colision = false;

		randTex = Random.Range (0, texAlly.Length);
		if (!valid) {
			mat.SetTexture ("_MainTex", texAlly [randTex]);
			source.PlayOneShot (scream[0], 0.5f);
		} else {
			mat.SetTexture ("_MainTex", texEnemy [randTex]);
			source.PlayOneShot (scream[1], 0.5f);
		}

		target = valid;

		this.transform.Rotate (90, 0, 0, Space.Self);

		StartCoroutine (ObjectiveDesapear (delay, valid));
	}

	private IEnumerator ObjectiveDesapear(float delay, bool valid){
		yield return new WaitForSecondsRealtime (delay);
		this.transform.Rotate (-90, 0, 0, Space.Self);


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
