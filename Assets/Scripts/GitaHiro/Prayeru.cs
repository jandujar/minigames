using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prayeru : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adeu siau");
        Debug.LogError("Fail!");
    }
    */
    /*void OnTriggerStay(Collider other)
    {
        //X BUTTON
        if (Input.GetKeyDown(KeyCode.A) && other.gameObject.name == "X(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.A) && other.gameObject.name != "X(Clone)")
            Debug.LogError("Fail!");
        //Y BUTTON
        if (Input.GetKeyDown(KeyCode.S) && other.gameObject.name == "Y(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.S) && other.gameObject.name != "Y(Clone)")
            Debug.LogError("Fail!");
        //A BUTTON
        if (Input.GetKeyDown(KeyCode.D) && other.gameObject.name == "A(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.D) && other.gameObject.name != "A(Clone)")
            Debug.LogError("Fail!");
        //B BUTTON
        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.name == "B(Clone)")
            Destroy(other.gameObject);
        else if (Input.GetKeyDown(KeyCode.F) && other.gameObject.name != "B(Clone)")
            Debug.LogError("Fail!");
    }
    */

    void destroyGameObject(GameObject _object)
    {
        Debug.Log("Destroying " + _object.name);
        Destroy(_object.gameObject);
    }
}
