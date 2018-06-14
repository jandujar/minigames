using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunnerControllerPlayer : MonoBehaviour {

	public AnimationClip[] animations;

	public GameObject explosion;
	public float gravity;

	//[Tooltip("Save vector of movement Player")]
	private Vector3 movement;
	//[Tooltip("Save vector of jumping Player")]
	private Vector3 jump;
	//[Tooltip("Speed of movement Sides Front")]
	public int speedMovement;
	//[Tooltip("Speed of Jumping Sides Front")]
	public int speedJump;
	//[Tooltip("Waiting Time animation Jump")]
	private float waitingTimeJump;
	//[Tooltip("Var Save Player is Jumping")]
	private bool jumping = false;
	//[Tooltip("Var Save Player is Slide")]
	private bool slide = false;
	//[Tooltip("Var Save Player is PotentialJumping")]
	private bool potencialJump = false;
	//[Tooltip("Var Save Player is NoTouch")]
	private bool potencialNoTouch = false;
	//[Tooltip("Var Save Posible Contact Again With Finish")]
	private bool noContactFinish = false;
	private bool notMoveRight = false;
	private bool notMoveLeft = false;

	//[Tooltip("Var Save Player is OverPowerd PowerUpJump")]
	private int countPotentialJumpSum = 0;
	//[Tooltip("Var Save Player is OverPowerd PowerUpJump")]
	private int countPotentialNoTouchSum = 0;

	private float capHeightCollider;

	//[Tooltip("Posible State Clip of Animator")]
	private enum animationState {Jump, Slide, Die};

	//[Tooltip("State of not Contact")]
	private enum noContactState {Power, Finish};

	//[Tooltip("Save Input Positive Negative Horizontal")]
	private float inputMovement;

	//[Tooltip("Animator Var")]
	private Animator animController;
	//[Tooltip("Rigidbody Var")]
	private Rigidbody rbd;
	//[Tooltip("Capsule Collider Var")]
	private CapsuleCollider capCollider;

	private AudioSource source;

	public AudioClip clipAudio;

	//private CharacterController charController;

	//private float heightCharacterController;

	// Use this for initialization
	void Start () {
		//TODO: No poner a mano
		//speedMovement = 8;
		//speedJump = 10;
		waitingTimeJump = 0.3f;
		//Siempre se mueve hacia delante
		movement.y = gravity;
		//Siempre se salta hacia arriba
		jump.y = 1;
		animController = this.GetComponent<Animator> ();
		rbd = this.GetComponent<Rigidbody> ();
		capCollider = this.GetComponentInChildren<CapsuleCollider> ();
		capHeightCollider = capCollider.height;
		source = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (WildWestRunnerManager.instance.getStartGame ()) {
			GetInputPlayer ();
			Move ();
		}
	}

	void Move(){
		movement.z = speedMovement;
		movement.x = inputMovement * speedMovement;
		rbd.velocity = movement;
	}

	void GetInputPlayer(){
		inputMovement = InputManager.Instance.GetAxisHorizontal ();
		if (notMoveLeft) {
			notMoveRight = false;
			if (inputMovement < 0) {
				inputMovement = 0;
			} else if (inputMovement > 0) {
				notMoveLeft = false;
			}
		}
		if (notMoveRight) {
			notMoveLeft = false;
			if (inputMovement > 0) {
				inputMovement = 0;
			} else if (inputMovement < 0) {
				notMoveRight = false;
			}
		}
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1)  && !jumping) {
			StartCoroutine (AnimationPlay (animationState.Jump));
		}

		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON2) && !jumping && !slide) {
			StartCoroutine (AnimationPlay (animationState.Slide));
		}

	}

	//**************************************************************************************** COLISION
	void OnTriggerEnter(Collider other){
			if (other.tag == "PowerUp") {
				Debug.Log ("Contact PowerUp");
				int type = (int)other.GetComponent<WildWestPowerUp> ().typePower;
				switch (type) {
				case 0:
					if (!potencialJump) {
						StartCoroutine (potentionJump (other.GetComponent<WildWestPowerUp> ().getTimeEffect (), other.GetComponent<WildWestPowerUp> ().getForceJump ()));
					} else {
						countPotentialJumpSum++;
					}
					break;
				case 1:
					if (!potencialNoTouch) {
						StartCoroutine (potentionNoTouch (other.GetComponent<WildWestPowerUp> ().getTimeEffect ()));
					} else {
						countPotentialNoTouchSum++;
					}
					break;
				default:
					break;
				}
				Destroy (other.gameObject);
			}

	}

	void OnCollisionEnter(Collision other){
		
		if (other.collider.tag == "Finish" && !noContactFinish) {
			noContactFinish = true;
			Debug.Log ("Colision Collider Enter");
			GameObject explode;
			explode = Instantiate (explosion) as GameObject;
			explode.transform.position = other.contacts [0].point;
			explode.GetComponent<ParticleSystem> ().Play ();
			Destroy (other.gameObject);
			Debug.Log ("Potente no touch: " + potencialNoTouch);
			if (!potencialNoTouch) {
				source.clip = clipAudio;
				source.Play ();
				StartCoroutine (AnimationPlay (animationState.Die));
				Debug.Log ("Se Acabo wey");
			}
			StartCoroutine (waitContactAgain (noContactState.Finish));
		}

		if (other.collider.tag == "EditorOnly") {
			Vector3 vecSeparacion = other.contacts [0].point - this.transform.position;
			if (vecSeparacion.x > 0) {
				notMoveRight = true;
			} else if( vecSeparacion.x < 0) {
				notMoveLeft = true;
			}
		}
			
	}

	//****************************************************************************************COROUTINE
	private IEnumerator AnimationPlay(animationState state){
		float waitTime = 0;
		switch (state) {
		case animationState.Jump:
			rbd.useGravity = false;
			jumping = true;
			for (int i = 0; i < animations.Length; i++) {
				if (animations [i].name == "WildWestJump") {
					waitTime = animations [i].length;
				}
			}
			movement.y = 1 * speedJump;
			animController.SetTrigger ("Jump");
			Debug.Log ("Velocity: " + rbd.velocity);
			yield return new WaitForSecondsRealtime (waitTime * waitingTimeJump);
			movement.y = gravity;
			yield return new WaitForSecondsRealtime ((waitTime  - (waitTime * waitingTimeJump)));
			jumping = false;
			animController.SetTrigger ("StopJump");
			waitTime = 0;
			break;
		case animationState.Slide:
			slide = true;
			for (int i = 0; i < animations.Length; i++) {
				if (animations [i].name == "WildWestRunnerSlide") {
					waitTime = animations [i].length;
				}
			}
			capCollider.height = capHeightCollider/2;
			animController.SetTrigger ("Slide");
			yield return new WaitForSecondsRealtime (waitTime);
			slide = false;
			capCollider.height = capHeightCollider;
			animController.SetTrigger ("StopSlide");
			waitTime = 0;
			break;
		default:
		case animationState.Die:
			speedMovement = 0;
			animController.SetTrigger ("Die");
			Debug.Log ("DIE");
			yield return new WaitForSecondsRealtime (4);
			WildWestRunnerManager.instance.endGame (IMiniGame.MiniGameResult.LOSE);
			break;
		}
	}

	private IEnumerator waitContactAgain(noContactState state){
		yield return new WaitForSecondsRealtime (0.2f);
		switch (state) {
		case noContactState.Power:

			break;
		case noContactState.Finish:
			noContactFinish = false;
			break;
		default:
			break;
		}
	}

	private IEnumerator potentionNoTouch(float waitTimeEffect){
		potencialNoTouch = true;
		yield return new WaitForSecondsRealtime (waitTimeEffect);
		potencialNoTouch = false;
		if (countPotentialNoTouchSum > 0) {
			countPotentialNoTouchSum--;
			StartCoroutine (potentionNoTouch (waitTimeEffect));
		}
	}

	private IEnumerator potentionJump(float waitTimeEffect, int multiplierJump){
		potencialJump = true;
		speedJump = speedJump * multiplierJump;
		Debug.Log ("SpeedJump: " + speedJump);
		waitingTimeJump = 0.05f;
		yield return new WaitForSecondsRealtime (waitTimeEffect);
		potencialJump = false;
		speedJump =  2;
		waitingTimeJump = 0.3f;
		if (countPotentialJumpSum > 0) {
			countPotentialJumpSum--;
			StartCoroutine (potentionJump (waitTimeEffect, multiplierJump));
		}
	}
		
	//****************************************************************************************SETTERS
	public void setSpeedMovement(int newSpeed){
		speedMovement = newSpeed;
	}

	//****************************************************************************************GETTERS
	public float getSpeedMovement(){
		return speedMovement;
	}

	public void addSpeed(int addingSpeed){
		speedMovement += addingSpeed;
	}
}
