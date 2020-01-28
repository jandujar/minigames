using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayContr : MonoBehaviour
{
    
   public Transform player;        

    float smooth = 5f;

    public Vector3 offset;  
    
    void Start () 
    {
        
    }

    
    void FixedUpdate () 
    {
        Vector3 goPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, goPosition, smooth);
        //offset = transform.position - player.transform.position; 
        transform.position = goPosition;
        //transform.position = player.transform.position + offset;

        //Camera.main.transform.Translate(smoothPosition);
    }
}
