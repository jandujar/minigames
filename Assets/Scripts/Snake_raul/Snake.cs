using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public GameObject camera;
    float xvel, zvel;
    enum Direcciones { delante, izquierda, derecha, detras };
    private Direcciones direcciones;

    // Use this for initialization
    void Start () {
        float zvel = 0f;
        float xvel = 0.02f;
        direcciones = Direcciones.delante;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(zvel, 0f, xvel);

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Debug.Log("izq");
                switch (direcciones)
                {
                    case Direcciones.delante:
                        xvel = 0;
                        zvel = -0.02F;
                        direcciones = Direcciones.izquierda;
                        break;
                    case Direcciones.izquierda:
                        xvel = -0.02F;
                        zvel = 0;
                        direcciones = Direcciones.detras;
                        break;
                    case Direcciones.detras:
                        xvel = 0;
                        zvel = 0.02F;
                        direcciones = Direcciones.derecha;
                        break;
                    case Direcciones.derecha:
                        xvel = 0.02F;
                        zvel = 0;
                        direcciones = Direcciones.delante;
                        break;
                    default:
                        break;
                }
            }

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                Debug.Log("der");
            switch (direcciones)
                {
                    case Direcciones.delante:
                        xvel = 0;
                        zvel = 0.02F;
                        direcciones = Direcciones.derecha;
                        break;
                    case Direcciones.izquierda:
                        xvel = 0.02F;
                        zvel = 0;
                        direcciones = Direcciones.delante;
                        break;
                    case Direcciones.detras:
                        xvel = 0;
                        zvel = -0.02F;
                        direcciones = Direcciones.izquierda;
                        break;
                    case Direcciones.derecha:
                        xvel = -0.02F;
                        zvel = 0;
                        direcciones = Direcciones.detras;
                        break;
                    default:
                        break;
                }
            }
        }

}


