using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalsePointer : MonoBehaviour {

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}