using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject virtualMousePosition;
	public GameObject manager;
	public GameObject bullet;
	public int forceShoot;
	public AudioClip shoot;

	private bool canFire;
	private bool shooting;
	private SphereCollider collBullet;
	private Rigidbody rbdBullet;
	private Vector3 startPosBullet;
	private Animator animController;
	private AudioSource source;


	void Awake(){
		canFire = true;
		shooting = false;
		collBullet = bullet.GetComponent<SphereCollider> ();
		rbdBullet = bullet.GetComponent<Rigidbody> (); 
		collBullet.enabled = false;
		rbdBullet.useGravity = false;
		startPosBullet = bullet.transform.position;
		animController = this.GetComponent<Animator> ();
		source = this.GetComponent<AudioSource> ();
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
		virtualMousePosition.GetComponent<JoystickMovement> ().posToLook = hitPoint.point;
		virtualMousePosition.transform.rotation = new Quaternion (virtualMousePosition.transform.rotation.x, this.transform.rotation.y, virtualMousePosition.transform.rotation.z, virtualMousePosition.transform.rotation.w);
		if (canFire) {
			bullet.transform.LookAt (hitPoint.point);
		}
	}

	private void CheckInputs(){
		//Disparar
		if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) && canFire && manager.GetComponent<ShootingManager>().getStartGame()){
			source.PlayOneShot (shoot, 0.5f);
			canFire = false;
			shooting = true;
		}
	}

	private void Fire(){
		shooting = false;
		collBullet.enabled = true;
		rbdBullet.AddForce (bullet.transform.forward * forceShoot);
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
