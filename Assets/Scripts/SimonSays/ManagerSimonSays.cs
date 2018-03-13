using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSimonSays : MonoBehaviour {

	//List All objective
	public GameObject[] buttons;
	//Object Render Simon Buttons
	public GameObject simon;
	//List of All sprite render of Simon
	public Sprite[] sprSimon;

	//Sprite Render Simon
	private SpriteRenderer sprRenderSimon;
	//Manager Game
	private GameManager gm;
	//Source Audio
	private AudioSource source;

	//Start Move Pointer
	private bool startGame;
	//Num Repeat
	private int numRepeat;
	//Random Button
	private int randButton;
	//Array repeat good
	public List<int> repeatButtons = new List<int>();
	//List Player
	public List<int> buttonsPlayer = new List<int>();
	//Audios
	public AudioClip[] beeps;

	private int count;
	private bool failGame;


	void Awake(){
		startGame = false;
		count = 0;
		failGame = false;
		source = this.GetComponent<AudioSource> ();
		sprRenderSimon = simon.GetComponent<SpriteRenderer> ();
	}

	public void InitGame(GameManager manager){
		gm 	= manager;
		StartCoroutine (waitLumus ());

	}


	private IEnumerator waitLumus(){
		yield return new WaitForSecondsRealtime (0.5f);
		randButton = Random.Range (0, buttons.Length);
		//Llamar funcion encendido Correcto
		buttons [randButton].GetComponent<ButtonSimonSays>().emitLumus(true);

		//Set Simon Color
		sprRenderSimon.sprite = sprSimon [randButton];

		source.PlayOneShot (beeps[randButton], 0.5f);
		repeatButtons.Add(randButton);
		yield return new WaitForSecondsRealtime (0.5f);

		//Set Normal Simon
		sprRenderSimon.sprite = sprSimon [sprSimon.Length - 3];

		count++;
		if (count < numRepeat) {
			StartCoroutine (waitLumus ());
		} else {
			startGame = true;
		}
	}

	private IEnumerator butttonPulse(bool pulse){
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].GetComponent<ButtonSimonSays> ().emitLumus (pulse);
			if (pulse) {
				sprRenderSimon.sprite = sprSimon [sprSimon.Length - 2];
				source.PlayOneShot (beeps [beeps.Length - 1], 0.5f);
			} else {
				sprRenderSimon.sprite = sprSimon [sprSimon.Length - 1];
				source.PlayOneShot (beeps [beeps.Length - 2], 0.5f);
			}
		}
		yield return new WaitForSeconds (7);
		if (pulse) {
			endGame (IMiniGame.MiniGameResult.WIN);
		} else {
			endGame (IMiniGame.MiniGameResult.LOSE);
		}

	}

	public void addButtonPlayer(int buttonNum){
		buttonsPlayer.Add (buttonNum);
		for (int i = 0; i < buttonsPlayer.Count; i++) {
			if (buttonsPlayer [i] != repeatButtons [i]) {

				//Sonido fallo llamar halo lose
				StartCoroutine(butttonPulse(false));
				failGame = true;
				break;
			}
			//SONIDO ACIERTO 
		}

		if (!failGame) {
			source.PlayOneShot (beeps[buttonNum], 0.5f);
			sprRenderSimon.sprite = sprSimon [buttonNum];
			buttons [buttonNum].GetComponent<ButtonSimonSays> ().emitLumus (true);
			StartCoroutine (SimonStable ());

			if (buttonsPlayer.Count == repeatButtons.Count) {
				StartCoroutine(butttonPulse(true));
			}
		}

	}

	private IEnumerator SimonStable(){
		yield return new WaitForSeconds (1.5f);
		sprRenderSimon.sprite = sprSimon [sprSimon.Length - 3];
	}

	//*******************************************************************************************SETTERS

	public void endGame(IMiniGame.MiniGameResult res){
		gm.EndGame (res);
	}

	public void setNumRepeat(int num){
		numRepeat = num;
	}

	public bool getStartGame(){
		return startGame;
	}

}
