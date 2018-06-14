using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour {

    public float xSize = 623f;
    public float zSize = 165f;

    public Vector3 curPos;

    public GameObject coinPrefab;
    public GameObject currCoin;


	// Use this for initialization
	void Start () {

        currCoin = GameObject.Instantiate(coinPrefab,curPos, Quaternion.identity) as GameObject;

	}
	
    void RandomPos()
    {
        curPos = new Vector3(Random.Range(xSize * -1, xSize), -166.7f, Random.Range(zSize * -1, zSize));
    }

	// Update is called once per frame
	void Update () {
		
	}
}
