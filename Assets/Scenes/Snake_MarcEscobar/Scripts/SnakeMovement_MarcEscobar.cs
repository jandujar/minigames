using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement_MarcEscobar : MonoBehaviour {
	public float moveSpeed = 5;
	public GameObject[] snakeParts;
	public float interpolation;
	public bool miau = true;

	private List<GameObject> tails = new List<GameObject>();
	public GameObject snakeTail;
	private int SIZE = 0;
	private float tailDistance = 0.3f;
	public Snake_MarcEscobar snake;

	// Use this for initialization
	void Start () {

		InvokeRepeating("InstantiateTail",0,0.13f);

	}
	
	// Update is called once per frame
	void Update () {
		if (!snake.gameStarted) {
			return;
		}
		CheckInputs ();
		Move ();
	}

	public void RotateSnake(int rotation){
		transform.Rotate(0,rotation,0);
	}

	private void CheckInputs(){
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON1)) {
			//Gira izq
			RotateSnake(-90);
		}
		if (InputManager.Instance.GetButtonDown (InputManager.MiniGameButtons.BUTTON2)) {
			//Gira izq
			RotateSnake(90);
		}
	}
	//Cola de la serpiente
	private void InstantiateTail(){
		if (SIZE == 0) {
			return;
		}
		Vector3 back = -transform.forward;
		tails.Add(Instantiate (snakeTail, transform.position +(back *tailDistance), transform.rotation));
		//si hay el maximo de tails
		if (tails.Count > SIZE) {
			//eliminamos la primera
			Destroy(tails[0].gameObject);
			tails.RemoveAt(0);
		}
	}
	//Movimiento
	private void Move(){
		transform.Translate(transform.forward*moveSpeed *Time.deltaTime,Space.World);

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Contains("Coin")) {
			SIZE++;
			Destroy (col.gameObject);
			if (SIZE >= 20) {
				Win ();
			}
		}
		if (col.gameObject.name.Contains ("Death") || col.gameObject.name.Contains("Snake")) {
			Lose ();
		}
	}

	void Win(){
		snake.gameManager.EndGame (IMiniGame.MiniGameResult.WIN);
	}
	void Lose(){
		snake.gameManager.EndGame (IMiniGame.MiniGameResult.LOSE);
	}
}
