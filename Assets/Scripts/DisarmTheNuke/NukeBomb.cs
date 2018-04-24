using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("bombEnter");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().CanDisarmBomb = true;
            Debug.Log("bombEnter");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().CanDisarmBomb = false;
        }
    }
}
