using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoArrow : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.eulerAngles = transform.eulerAngles - new Vector3(30, 0, 0);
    }


}
