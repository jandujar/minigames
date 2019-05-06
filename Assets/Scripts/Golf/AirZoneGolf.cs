using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirZoneGolf : MonoBehaviour
{

    [SerializeField] float airSpeed;

    void Rotate(Vector3 rotation)
    {
        transform.localRotation = Quaternion.Euler(rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * airSpeed);
        }
    }
}

