using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {
    private Slider powerBar;
    private float powerBarTreshold = 10f;
    private float powerBarValue = 0f;
    private Rigidbody rb;
    private float power = 25f;
    private InputManager im;

	// Use this for initialization
	void Start () {
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBar.minValue = 0f;
        powerBar.maxValue = 10f;
        powerBar.value = powerBarValue;
        rb = GetComponent<Rigidbody>();

    }
    public void SetPower()
    {
        /*if (Input.GetButton(im.MiniGameButtons.BUTTON1))
        {

        }*/
        if (Input.GetKey(KeyCode.Space))
        {
            //powerBarValue = powerBarTreshold * Time.deltaTime;
            //powerBar.value = powerBarValue;
            rb.AddForce(0, power, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        SetPower();

    }
}
