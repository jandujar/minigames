using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRolling : MonoBehaviour {

	//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
	private ArrayList objectsToSpawn;
	public Vector3 pos1; //middle
	public Vector3 pos2; //left
	public Vector3 pos3; //right
	public GameObject parent; 
	private int lastPos;
	private float spawnTime;

	// Use this for initialization
	void Start () {
		StartCoroutine(CallSpawn());
	}

	IEnumerator CallSpawn(){
		yield return new WaitForSeconds(3);
		for(int i = 0; i < 25; ++i){
			Spawn();
			spawnTime = Random.Range(0.4f, 0.7f);
			yield return new WaitForSeconds(spawnTime);
		}
	}
	void Spawn(){
			int random = Random.Range(0, 3);

			while(lastPos == random){
				random = Random.Range(0, 3);
			}	
			
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<Transform>().localScale = new Vector3(0.7f, 1, 1);
			cube.AddComponent<Rigidbody>();
			cube.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionZ | 
				RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
			cube.GetComponent<Rigidbody>().useGravity = false;
			switch(random){
				case 0:
					cube.gameObject.transform.localPosition = pos1;
					cube.transform.SetParent(parent.transform, true);
					break;
				case 1:
					cube.gameObject.transform.localPosition = pos2;
					cube.transform.eulerAngles = new Vector3(
						cube.transform.eulerAngles.x + 20,
						cube.transform.eulerAngles.y,
						cube.transform.eulerAngles.z
					);
					cube.transform.SetParent(parent.transform, true);
					break;
				case 2:
					cube.gameObject.transform.localPosition = pos3;
					cube.transform.eulerAngles = new Vector3(
						cube.transform.eulerAngles.x - 20,
						cube.transform.eulerAngles.y,
						cube.transform.eulerAngles.z
					);
					cube.transform.SetParent(parent.transform, true);
					break;

				default: 
					break;
			}
			lastPos = random;
	}
    void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
