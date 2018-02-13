using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour {
	public float speed = .5f;
	public float turnSpeed = 60;
	private Rigidbody rig;
	public float distance;
	public Transform target;
	public Transform mouseposition;
	public float maxdist;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {

		Vector3 targetpos = target.transform.position;

		mouseposition = rig.transform;
		distance = (Vector2.Distance(transform.position, target.transform.position));

		if (Vector2.Distance(transform.position, target.transform.position) <= maxdist)
		{
			float rStickX = InputManager.Instance.GetAxisHorizontal ();
			float rStickY = InputManager.Instance.GetAxisVertical ();

			Vector3 movement = new Vector3(rStickX, rStickY, 0);

			rig.MovePosition(transform.position + movement / speed);
		}
		mouseposition = rig.transform;
	}  
}