using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumFront : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.gameObject.GetComponent<BrumCar>().OnTriggerEnterChild(other);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.gameObject.GetComponent<BrumCar>().OnTriggerExitChild(other);
    }
}
