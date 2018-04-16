using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player") {
            other.GetComponent<BrumPlayer>().Kill();
        }
    }
}
