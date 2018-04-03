using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

    float power;
    float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;

	// Use this for initialization
	void Start () {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
	}
	
	// Update is called once per frame
	void Update () {
        powerSlider.value = power;

        if(ballList.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(power <= maxPower){
                    power += 50 * Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
              foreach(Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }

	}

    private void OnTriggerEnter ( Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
