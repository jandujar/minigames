using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDoor : MonoBehaviour {
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "out" && collision.gameObject.tag == "Finish")
        {
            this.name = "in";
            this.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
        }
    }   
}
