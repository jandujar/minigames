using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prayeru : MonoBehaviour {
    /*
    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
    */
	// Update is called once per frame
	void Update () {
        /*
        move = Input.GetAxis("Vertical");

        transform.Translate(0, move * vely * Time.deltaTime, 0);

        if(transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Holi");
    }
    void OnTriggerStay(Collider other)
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
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Adeu siau");
        Debug.LogError("Fail!")
    }

    void destroyGameObject(GameObject _object)
    {
        Debug.Log("Destroying " + _object.name);
        Destroy(_object.gameObject);
    }
}
