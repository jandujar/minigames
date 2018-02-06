using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabraController : MonoBehaviour {

    public float StartForce = 0;

    public Transform InitPos;

    public Vector2 Direction;

    Rigidbody2D Rig;

    public float foreCounter = 0;
    public float potencia = 0;

    public float incrementSpeed = 0;

    public bool pulsado = false;

    public int multiply = 1;

    public Image barra;

    public AnimationCurve animCurve;

	// Use this for initialization
	void Start () {
        Rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            pulsado = true;
            foreCounter = foreCounter + Time.deltaTime*incrementSpeed*multiply;
            // potencia = animCurve.Evaluate(foreCounter);
            //barra.fillAmount = potencia;
            barra.fillAmount = foreCounter;
            if(foreCounter >= 1)
            {
                multiply = -1;
            }
            else if(foreCounter<=0)
            {
                multiply = 1;
            }

        }
        else if (pulsado){
            pulsado = false;
            //Rig.AddForce(Direction * StartForce * potencia);
            Rig.AddForce(Direction * StartForce * foreCounter);
            foreCounter = 0;
            multiply = 1;
            barra.gameObject.SetActive(false);
       
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            transform.position = InitPos.position;
            Rig.velocity = new Vector2(0, 0);
            barra.gameObject.SetActive(false);
        }
    }

}
