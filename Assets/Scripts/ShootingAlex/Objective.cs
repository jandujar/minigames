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
	public Texture[] texEnemy;
	public Texture[] texAlly;

	public void Awake(){
		mat = this.GetComponentInChildren<MeshRenderer> ().materials [0];
		startRotation = this.transform.rotation.eulerAngles;
		target = false;
	}

	public void moveUp(bool valid, float delay){
		colision = false;

		randTex = Random.Range (0, texAlly.Length);
		if (!valid) {
			mat.SetTexture ("_MainTex", texAlly [randTex]);
		} else {
			mat.SetTexture ("_MainTex", texEnemy [randTex]);
		}

		this.transform.Rotate (90, 0, 0, Space.Self);

		StartCoroutine (ObjectiveDesapear (delay, valid));
	}

	private IEnumerator ObjectiveDesapear(float delay, bool valid){
		yield return new WaitForSecondsRealtime (delay);
		this.transform.Rotate (-90, 0, 0, Space.Self);
		target = valid;

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
			manageShooting.GetComponent<ShootingManager> ().InitGame ();
		}
	}

	private void OnCollisionEnter(Collision other){
		if (other.collider.tag == "Bullet" && target) {
			colision = true;
			Debug.Log ("WIN");
		}
	}
}
