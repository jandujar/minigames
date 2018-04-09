using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public GameObject Bowl1;
    public GameObject Bowl2;
    public GameObject Bowl3;
    public GameObject Bowl4;
    public GameObject Bowl5;
    public GameObject Bowl6;
    public GameObject Bowl7;
    public GameObject Bowl8;
    public GameObject Bowl9;
    public GameObject Bowl10;

    bool bowl1Changed = false;
    bool bowl2Changed = false;
    bool bowl3Changed = false;
    bool bowl4Changed = false;
    bool bowl5Changed = false;
    bool bowl6Changed = false;
    bool bowl7Changed = false;
    bool bowl8Changed = false;
    bool bowl9Changed = false;
    bool bowl10Changed = false;
  


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Bowl1.transform.hasChanged)
                {
                    Debug.Log("change bowl1");
                    transform.hasChanged = false;
                    bowl1Changed = true;
                }
            
        

      
            if (Bowl2.transform.hasChanged && bowl2Changed == false)
            {
                Debug.Log("change bowl2");
                transform.hasChanged = false;
                bowl2Changed = true;
            }
        

       
            if (Bowl3.transform.hasChanged && bowl3Changed == false)
            {
                Debug.Log("change bowl3");
                transform.hasChanged = false;
                bowl3Changed = true;
            }
        

            if (Bowl4.transform.hasChanged && bowl4Changed == false)
            {
                Debug.Log("change bowl4");
                transform.hasChanged = false;
                bowl4Changed = true;
            }
        

        
            if (Bowl5.transform.hasChanged && bowl5Changed == false)
            {
                Debug.Log("change bowl5");
                transform.hasChanged = false;
                bowl5Changed = true;
            }
        

      
            if (Bowl6.transform.hasChanged && bowl6Changed == false)
            {
                Debug.Log("change bowl6");
                transform.hasChanged = false;
                bowl6Changed = true;
            }
        

       
            if (Bowl7.transform.hasChanged && bowl7Changed == false)
            {
                Debug.Log("change bowl7");
                transform.hasChanged = false;
                bowl7Changed = true;
            }
        

       
            if (Bowl8.transform.hasChanged && bowl8Changed == false)
            {
                Debug.Log("change bowl8");
                transform.hasChanged = false;
                bowl8Changed = true;
            }
        

        
            if (Bowl9.transform.hasChanged && bowl9Changed == false)
            {
                Debug.Log("change bowl9");
                transform.hasChanged = false;
                bowl9Changed = true;
            }
        

      
            if (Bowl10.transform.hasChanged && bowl10Changed == false)
            {
                Debug.Log("change bowl10");
                transform.hasChanged = false;
                bowl10Changed = true;
            }
        
    }
}
