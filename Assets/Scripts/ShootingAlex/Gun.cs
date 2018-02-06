using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject virtualMousePosition;
	public GameObject bullet;
	public int forceShoot;

	private bool canFire;
	private bool shooting;
	private SphereCollider collBullet;
	private Rigidbody rbdBullet;
	private Vector3 startPosBullet;
	private Animator animController;


	void Awake(){
		canFire = true;
		shooting = false;
		collBullet = bullet.GetComponent<SphereCollider> ();
		rbdBullet = bullet.GetComponent<Rigidbody> (); 
		collBullet.enabled = false;
		rbdBullet.useGravity = false;
		startPosBullet = bullet.transform.position;
		animController = this.GetComponent<Animator> ();
	}


	void Update(){
		CheckInputs ();
		if (!collBullet.enabled) {
			bullet.transform.position = (this.transform.position + this.transform.forward * 0.5f);
		}
		if (shooting) {
			Fire ();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Ray ray = new Ray (Camera.main.transform.position, Input.mousePosition - Camera.main.transform.position);
		Ray ray = new Ray (Camera.main.transform.position, virtualMousePosition.transform.position - Camera.main.transform.position);
		RaycastHit hitPoint;
		Physics.Raycast (ray, out hitPoint, 100);
		Debug.DrawRay (Camera.main.transform.position, hitPoint.point - Camera.main.transform.position, Color.green, 10);
		this.transform.LookAt (hitPoint.point);
	}

	private void CheckInputs(){
		//Disparar
		if(Input.GetMouseButtonDown(0) && canFire){
			canFire = false;
			shooting = true;
		}
	}

	private void Fire(){
		shooting = false;
		collBullet.enabled = true;
		rbdBullet.AddRelativeForce (bullet.transform.forward * forceShoot);
		rbdBullet.useGravity = true;
		StartCoroutine (Reload ());
		//bullet.GetComponent<Ri
	}

	private IEnumerator Reload(){
		yield return new WaitForSecondsRealtime (1);
		rbdBullet.velocity = Vector3.zero;
		rbdBullet.useGravity = false;
		collBullet.enabled = false;
		canFire = true;
	}

}
