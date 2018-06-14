using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour {

public float minWaitTime;
public float maxWaitTime;
public Light MuzzleFlashLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
void Update () {
	
MuzzleFlashLight = GetComponent<Light>();
StartCoroutine(Flashing());
}

	IEnumerator Flashing ()
	{
  
  while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
			MuzzleFlashLight.enabled = !MuzzleFlashLight.enabled;

		}

	
}
}
