using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paf_Hand : MonoBehaviour {

    public GameObject hand_win;
    public GameObject hand_lose;

    void Start() {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("entered");
        if (coll.gameObject.name == "Fish") {
            FinishMinigame(true);
        }

    }

    public void FinishMinigame(bool result) {
        GetComponent<SpriteRenderer>().enabled = false;
        if (result)
        {
            hand_win.SetActive(true);
        }
        else
        {
            hand_lose.SetActive(true);
        }
    }
}
