using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestRunnerControllerPlayer : MonoBehaviour {


	//[Tooltip("Save vector of movement Player")]
	private Vector3 movement;

	private float speedMovement;

	private bool jumping;

	private enum animationState {Jump, Slide};


	//[Tooltip("Save Input Positive Negative Horizontal")]
	private float inputMovement;



	private Animator animController;

	// Use this for initialization
	void Start () {
		//TODO: No poner a mano
		speedMovement = 2;
		animController = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//InputManager.Instance.GetAxisHorizontal ();
		Debug.Log (InputManager.Instance.GetAxisHorizontal ());
		GetInputPlayer ();
		Move ();
	}

	void Move(){
		movement.x = inputMovement;
		this.transform.Translate (movement * Time.deltaTime * speedMovement, Space.World);
		this.transform.Translate (Vector3.forward * Time.deltaTime * speedMovement, Space.World);
	}

	void GetInputPlayer(){
		//Save Input Movement Left Right
		inputMovement = InputManager.Instance.GetAxisHorizontal ();
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1)  && !jumping) {
			StartCoroutine (AnimationPlay (animationState.Jump));
		}

	}

	//****************************************************************************************COROUTINE
	private IEnumerator AnimationPlay(animationState state){
		switch (state) {
		case animationState.Jump:
			jumping = true;
			animController.SetTrigger ("Jump");
			AnimatorTransitionInfo animTransInfo = animController.GetAnimatorTransitionInfo (0);
			AnimatorClipInfo[] animClipInfo = animController.GetCurrentAnimatorClipInfo (0);
			for (int i = 0; i < animClipInfo.Length; i++) {
				AnimationClip animClip = animClipInfo [i].clip;
				Debug.Log("Clip info: " + animClip.name);
			}
			break;
		case animationState.Slide:

			break;
		default:
			Debug.LogError ("STATE NOT FOUND");
			break;
		}

		yield return new WaitForSecondsRealtime (0.2f);
		jumping = false;
	}


	//****************************************************************************************SETTERS
	public void setSpeedMovement(float newSpeed){
		speedMovement = newSpeed;
	}

	//****************************************************************************************GETTERS
	public float getSpeedMovement(){
		return speedMovement;
	}
}
