using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour {

	public GameObject target;
	public GameObject skull;
	public GameObject Spawner;
	public Transform toSpawn;
	float random;
	private Quaternion spawnQ = new Quaternion(0, 0, 0, 0);
	public bool isTarget;

	IEnumerator SpawnCooldown(){
		yield return new WaitForSeconds (random);
		Spawn ();
		StartCoroutine (SpawnCooldown());
	}

	void Start(){
		StartCoroutine (SpawnCooldown());


	}

	void Update(){
		random = Random.Range (2f, 4f);
	}
	

	void Spawn ()
	{
		if (isTarget) {
			Instantiate (target, toSpawn.position, spawnQ, toSpawn);
		} else {
			Instantiate (skull, toSpawn.position, spawnQ, toSpawn);
		}
	}
}
