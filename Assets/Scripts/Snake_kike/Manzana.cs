using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    int posX;
    Vector3 a;

    int extension = -1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Body" || other.tag == "Wall" || other.tag == "Player"){
            posX = Random.Range(-14, extension);

            int posY = Random.Range(-7, 7);
            a = new Vector3(posX, posY, 0);
            transform.position = a;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Body" || other.tag == "Wall" || other.tag == "Player"){
            posX = Random.Range(-14, extension);

            int posY = Random.Range(-7, 7);
            a = new Vector3(posX, posY, 0);
            transform.position = a;

        }
    }


    public void setPosX(int pos){
        extension = pos;
    }
    
}
