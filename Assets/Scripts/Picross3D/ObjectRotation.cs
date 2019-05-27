using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{

    public float speedX, speedY, speedZ = 0;




    // Update is called once per frame
    void Update()
    {

        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);


    }
}
