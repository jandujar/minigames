using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumPlayer : BrumCar {

    public override void OnTriggerEnterChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerStayChild(Collider collider)
    {
        isColliding = true;
    }

    public override void OnTriggerExitChild(Collider collider)
    {
        isColliding = false;
    }
}
