using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour {
	public float speed;
	private float rStickX;
	private float rStickY;
	private Vector3 movement;
	public float distance;
	public Transform target;
	public Transform mouseposition;
	public float maxdist;
	public Vector3 posToLook;
	public GameObject manager;

	void Update() {
		if (manager.GetComponent<ShootingManager> ().getStartGame ()) {
			rStickX = InputManager.Instance.GetAxisHorizontal ();
			rStickY = InputManager.Instance.GetAxisVertical ();

			movement = new Vector3 (rStickX, rStickY, 0);

			this.transform.Translate (movement * Time.deltaTime * speed, Space.World);

			this.transform.LookAt (posToLook);
			mouseposition = transform;
		}
	}

}