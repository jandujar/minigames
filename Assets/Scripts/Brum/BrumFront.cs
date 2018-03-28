using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumFront : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Car") return;
        if (transform.parent.transform.name != "Player")
        {
            transform.parent.gameObject.GetComponent<BrumCar>().OnTriggerEnterChild(other);
        }
        else {
            transform.parent.gameObject.GetComponent<BrumPlayer>().OnTriggerEnterChild(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Car") return;
        if (transform.parent.transform.name != "Player")
        {
            transform.parent.gameObject.GetComponent<BrumCar>().OnTriggerExitChild(other);
        }
        else
        {
            transform.parent.gameObject.GetComponent<BrumPlayer>().OnTriggerExitChild(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag != "Car") return;
        
        if (transform.parent.transform.name != "Player")
        {
            transform.parent.gameObject.GetComponent<BrumCar>().OnTriggerStayChild(other);
        }
        else
        {
            transform.parent.gameObject.GetComponent<BrumPlayer>().OnTriggerStayChild(other);
        }
    }
}
