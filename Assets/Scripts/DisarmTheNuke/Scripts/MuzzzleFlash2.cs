using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzzleFlash2 : MonoBehaviour {
	
public float minWaitTime;
public float maxWaitTime;
public Renderer muzzleflash;

	// Use this for initialization
	void Start () {
	gameObject.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
	
muzzleflash = GetComponent<Renderer>();
muzzleflash.enabled = true;
transform.Rotate(0,Random.Range (359, 0),0);
StartCoroutine(Flashing());
}
IEnumerator Flashing ()
	{
  
  while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
			muzzleflash.enabled = !muzzleflash.enabled;

		}
	}
}
