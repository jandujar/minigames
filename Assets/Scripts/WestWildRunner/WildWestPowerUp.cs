using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildWestPowerUp : MonoBehaviour {

	public enum typePowerUp {PotentialJump, Notouch};
	public typePowerUp typePower;

	private int forceJump;
	private float timeEffect;

	// Use this for initialization
	void Start () {
		switch (typePower) {
		case typePowerUp.PotentialJump:
			forceJump = 2;
			timeEffect = 60;
			break;
		case typePowerUp.Notouch:
			timeEffect = 15;
			break;
		default:
			Debug.LogError ("NOT TYPE OF POWER UP");
			break;
		}
	}

	public int getForceJump(){
		return forceJump;
	}

	public float getTimeEffect(){
		return timeEffect;
	}
}
