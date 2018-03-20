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

	// Use this for initialization
	void Start () {
		StartCoroutine(CallSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CallSpawn(){
		yield return new WaitForSeconds(4);
		for(int i = 0; i < 15; ++i){
			Spawn();
			yield return new WaitForSeconds(1);
		}
	}
	void Spawn(){
			int random = Random.Range(0, 3);
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent<Rigidbody>();
			cube.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionZ | 
				RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
			cube.GetComponent<Rigidbody>().useGravity = false;
			//cube.GetComponent<Collider>().isTrigger = true;
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
	}
    void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
