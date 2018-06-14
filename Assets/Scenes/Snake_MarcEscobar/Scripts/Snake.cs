using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
	public float moveSpeed = 5;
	public GameObject[] snakeParts;
	public float interpolation;

	private List<GameObject> tails = new List<GameObject>();
	public GameObject snakeTail;
	private int SIZE = 5;
	private float tailDistance = 0.4f;
	// Use this for initialization
	void Start () {
//		init ();
		InvokeRepeating("InstantiateTail",0.15f,0.15f);

	}
	
	// Update is called once per frame
	void Update () {
		CheckInputs ();
		Move ();
	}

	public IEnumerator RotateSnake(int rotation){
//		for (int i = 0; i < snakeParts.Length; i++) {
//			snakeParts [i].transform.Rotate(0,rotation,0);
//			yield return new WaitForSeconds (interpolation);
//		}
		transform.Rotate(0,rotation,0);
		yield return null;
	}
//	private void init(){
//		snakeParts [0] = this.transform.gameObject;
//		for (int i = 1; i < SIZE; i++) {
//			snakeParts [i] = Instantiate(snakeTail,new Vector3(transform.position.x,transform.position.y,snakeParts [i-1].transform.position.z - tailDistance),transform.rotation);
//		}
//	}
	private void CheckInputs(){
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1)) {
			//Gira izq
			StartCoroutine(RotateSnake(-90));
		}
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON2)) {
			//Gira izq
			StartCoroutine(RotateSnake(90));
		}
	}
	private void InstantiateTail(){
		if (SIZE == 0) {
			return;
		}
		Vector3 back = -transform.forward;
		tails.Add(Instantiate (snakeTail, transform.position +(back *tailDistance), transform.rotation));
		if (tails.Count > SIZE) {
			//eliminamos la primera
			Destroy(tails[0].gameObject);
			tails.RemoveAt(0);
		}
	}
	private void Move(){
//		for (int i = 0; i < snakeParts.Length; i++) {
//			snakeParts [i].transform.Translate (snakeParts [i].transform.forward * moveSpeed * Time.deltaTime,Space.World);
//		}
//
		transform.Translate(transform.forward*moveSpeed *Time.deltaTime,Space.World);

	}
}
