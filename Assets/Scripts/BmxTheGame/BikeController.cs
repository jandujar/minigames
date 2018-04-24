using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour {

	[Header("──────────Bike Vars──────────")]
	public float minSpeed = 1000f;
	public float maxSpeed = 3000f;
	private float actualSpeed;
	public float rotSpeed = 15f;
	public float airRotSpeed = 5f;
	public float jumpForce = 5;

	[Header("──────────Wheel Vars─────────")]
	public WheelJoint2D backWheelJoint;
	public WheelJoint2D frontWheelJoint;
	public Wheel backWheel;
	public Wheel frontWheel;

	[Header("──────────OTHER─────────")]
	public GameObject character;
	public GameObject ragdoll;
	public Animator charAnimator;

	//─────────────────────PRIVATE
	private bool increaseSpeed = false;
	private float movement;
	private float rotation;
	private Rigidbody2D myRigidBody;
	private float v,h;
	private bool dead;
	private Vector3 initPos;
	private Quaternion initRot;
	public bool gameStarted = false;
	public BmxTheGame bmxManager;
	private float timeMultiplier = 60;
	//────────────────────────────────────────────────────────────────────────────────────START
	void Start () {
		myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		initPos = transform.position;
		initRot = transform.rotation;
		actualSpeed = minSpeed;
	}
	
	//────────────────────────────────────────────────────────────────────────────────────UPDATE
	void Update () {
		if (!dead && gameStarted) {
			
			CheckInputs ();

			AnimationUpdate ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			transform.position = initPos;
			transform.rotation = initRot;
			dead = false;
		}
	
	}
	void FixedUpdate(){
		if (!dead) {
			SpeedIncrease ();
			MoveBike ();
			RotateBike ();
		}
	}
	//────────────────────────────────────────────────────────────────────────────────────Check user inputs
	private void CheckInputs(){
		/*v = -Input.GetAxisRaw ("Vertical");
		h = Input.GetAxisRaw ("Horizontal");*/
		v = -InputManager.Instance.GetAxisVertical ();
		h = InputManager.Instance.GetAxisHorizontal ();

		if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) {
			Jump ();
		}
	}

	public void AnimationUpdate(){
		charAnimator.SetFloat ("Paddle", v);
	}

	//────────────────────────────────────────────────────────────────────────────────────Check speed Increase
	private void SpeedIncrease(){
		if (v < 0 && isGrounded() && actualSpeed < maxSpeed) {

			actualSpeed += 20;
		}
		if(myRigidBody.velocity.x <=2 && actualSpeed > minSpeed){
			actualSpeed -= 20;
		}
	}

	//────────────────────────────────────────────────────────────────────────────────────Move the bike
	private void MoveBike(){
		movement = v * actualSpeed * Time.deltaTime * timeMultiplier;

		//BRAKE
		if (v > 0 && myRigidBody.velocity.x > 0) {
			frontWheelJoint.useMotor = true;
		} else {
			frontWheelJoint.useMotor = false;
		}

		//MOTOR
		if (movement == 0f) {
			backWheelJoint.useMotor = false;
		} else {
			backWheelJoint.useMotor = true;
			JointMotor2D motor = new JointMotor2D{ motorSpeed = movement, maxMotorTorque =500000 };
			backWheelJoint.motor = motor;
		}
	}

	//────────────────────────────────────────────────────────────────────────────────────Rotates the bike
	private void RotateBike(){
		if (!isGrounded ()) {
			rotation = h * airRotSpeed  * Time.deltaTime * timeMultiplier;
		} else {
			rotation = h * rotSpeed  * Time.deltaTime * timeMultiplier;
		}
		myRigidBody.AddTorque (-rotation);
	}
	//────────────────────────────────────────────────────────────────────────────────────JUMP
	private void Jump(){
		if (isGrounded () || backWheel.isGrounded()) {
			myRigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
	//────────────────────────────────────────────────────────────────────────────────────Check if the bike is grounded
	private bool isGrounded(){
		if (!frontWheel.isGrounded () && !backWheel.isGrounded ()) {
			return false;
		} else {
			return true;
		}
	}

	//────────────────────────────────────────────────────────────────────────────────────Ragdoll
	private void Ragdoll(){
		GameObject instance =  Instantiate (ragdoll, character.transform.position, character.transform.rotation);
		instance.GetComponent<Animator> ().enabled = false;
		Destroy (character);
	}

	IEnumerator gameFinished(){
		yield return new WaitForSecondsRealtime (2f);
		bmxManager.gameEnd (false);
	}
	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Finish") {
			bmxManager.gameEnd (true);
			return;
		}
		StartCoroutine ("gameFinished");
		dead = true;
		Ragdoll ();
	}
}
