using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Amuchalipsis_Player : MonoBehaviour
{
    float controlH;
    float controlV;
    float force = 15;
    public float maxStamina;
    float stamina;
    public float staminaWithRabbit;
    public float staminaWithMeteor;
    public bool StartPlay;
    public float TimeSurvive;
    Vector3 StartPos;
    [SerializeField] Amuchalipsis amuchalipsis;
    [SerializeField] Canvas AmuchalipsisCanvas;
    Image BarraStamina;
    TextMeshProUGUI TimeSurviveTEXT;




    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.position;
        stamina = maxStamina;

        BarraStamina = AmuchalipsisCanvas.transform.GetChild(0).GetComponent<Image>();
        TimeSurviveTEXT = AmuchalipsisCanvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (StartPlay){

        Move();
        reduceStamina();
        }

        //"alt!!"
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            moreStamina();
            //this.transform.position = StartPos;
    }

    private void Move()
    {
        controlH = InputManager.Instance.GetAxisHorizontal();
        controlV = InputManager.Instance.GetAxisVertical();

        gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position - new Vector3(controlH, -0.5F, controlV), 10, 0, ForceMode.Force);
    }

    private void reduceStamina()
    {
        if (stamina > 0)
            stamina -= Time.deltaTime;
        else
            amuchalipsis.Lose();

        BarraStamina.fillAmount = (stamina/maxStamina);

        TimeSurvive -= Time.deltaTime;
        if (TimeSurvive <= 0)
            amuchalipsis.Win();

        TimeSurviveTEXT.text = ((int)TimeSurvive % 60).ToString();
    }

    public void moreStamina()
    {
        if (stamina + staminaWithRabbit <= maxStamina)
            stamina += staminaWithRabbit;
        else
            stamina = maxStamina;

    }
    public void lessStamina()
    {
        stamina -= staminaWithMeteor;

    }
}


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