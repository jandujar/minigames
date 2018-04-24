using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDown : MonoBehaviour {

    Vector3 initialPos;
    Vector3 finalPos;
    bool Donete = false;
    public bool pin = false;

    public BallColWithMesh b;
    public winCondition w;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (b.ColDone && !Donete)
        {
            
            StartCoroutine(Timer());
            Donete = true;
        }

       
    }

    IEnumerator Timer()
    {
        initialPos = transform.position;
        //Debug.Log(initialPos);
        yield return new WaitForSeconds(5);
        finalPos = transform.position;
        pin = initialPos != finalPos;
        if (!pin) w.Defeated();

        w.CheckPlane();
        
        //Debug.Log(finalPos);
        
    }
        
    
}
