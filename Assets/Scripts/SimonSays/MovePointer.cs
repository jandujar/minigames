using UnityEngine;
using System.Collections;

public class MovePointer : MonoBehaviour {
	public float speed;
	public GameObject SimonManager;
	private BoxCollider colliderBox;
	public Transform mouseposition;

	private float rStickX;
	private float rStickY;
	private Vector3 movement;
	//public float maxdist;
	// Use this for initialization
	void Start () {
		colliderBox = this.GetComponent<BoxCollider> ();
	}

	void Update(){
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1) && SimonManager.GetComponent<ManagerSimonSays>().getStartGame()) {
			colliderBox.enabled = true;
			StartCoroutine (disableTrigger ());
		}
		if (SimonManager.GetComponent<ManagerSimonSays> ().getStartGame ()) {
			rStickX = InputManager.Instance.GetAxisHorizontal ();
			rStickY = InputManager.Instance.GetAxisVertical ();

			movement = new Vector3 (rStickX, rStickY, 0);

			this.transform.Translate (movement * Time.deltaTime * speed, Space.World);
			mouseposition = transform;
		}
	}

	private IEnumerator disableTrigger(){
		yield return new WaitForSeconds (0.2f);
		colliderBox.enabled = false;
	}

}