using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuchalipsis_Player : MonoBehaviour
{
    float controlH;
    float controlV;
    public float force = 15;
    Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        controlH = InputManager.Instance.GetAxisHorizontal();
        controlV = InputManager.Instance.GetAxisVertical();

        //up
        if (controlV > 0.1 && controlV >= lastControlV)
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(1, -0.5F, 0), 10, 0, ForceMode.Force);
        //down
        if (controlV < -0.1 && controlV <= lastControlV)
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(-1, -0.5F, 0), 10, 0, ForceMode.Force);
        //right
        if (controlH < -0.1 && controlH >= lastControlH)
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(0, -0.5F, 1), 10, 0, ForceMode.Force);
        //left
        if (controlH > 0.1 && controlH <= lastControlH)
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(0, -0.5F, -1), 10, 0, ForceMode.Force);

        lastControlH = controlH;
        lastControlV = controlV;
        */
        //-------------------------------------------------------------
        controlH = InputManager.Instance.GetAxisHorizontal();
        controlV = InputManager.Instance.GetAxisVertical();
        

            gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(controlH, -0.5F, controlV), 10, 0, ForceMode.Force);
        /*
        lastControlH = controlH;
        lastControlV = controlV;
        */

        //"alt!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            this.transform.position = StartPos;


    }
}
