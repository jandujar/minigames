using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCar : MonoBehaviour
{
    // Start is called before the first frame update
    public bool leftCollider;
    public CarIA carIA;
    private void OnTriggerStay(Collider other) {

        
        if(other.tag == "Walls")
        {
            
            if(leftCollider)
            {
                carIA.goLeft();
            }else{
      
                carIA.goRight();
            }
        }
        

    }
}
