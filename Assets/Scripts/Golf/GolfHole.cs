using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHole : MonoBehaviour
{

    [SerializeField] string winSound;
    [SerializeField] GolfController manager;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.LogError("SoundWin");
            manager.NextRound();
        }
    }
}

