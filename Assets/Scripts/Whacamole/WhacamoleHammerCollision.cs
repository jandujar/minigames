using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhacamoleHammerCollision : MonoBehaviour {

    public WhacamoleMove resetMole; 


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player") ;

    }

}
