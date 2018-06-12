using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public GameObject camera;
    private Vector3 offset;
    float xvel, zvel;
   // enum Direcciones { delante, izquierda, derecha, detras };
    //private Direcciones direcciones;
    private Vector3 Rotation;


    // Use this for initialization
    void Start () {
        zvel = 0f;
        xvel = 0.02f;
        offset = new Vector3(0,1.2f,-4);
        //direcciones = Direcciones.delante;
    }
	
	void Update () {

        transform.Translate(zvel, 0f, xvel);

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Debug.Log("izq");
                xvel = 0.02F;
                zvel = 0;
                Rotation = new Vector3(0, -90, 0);
                offset = new Vector3(0, 1.2f, 4);
                transform.Rotate(Rotation);
            /* switch (direcciones)
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
             }*/
        }

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                Debug.Log("der");
            xvel = 0.02F;
            zvel = 0;
            Rotation = new Vector3(0, 90, 0);
            transform.Rotate(Rotation);
            /*switch (direcciones)
                {
                    case Direcciones.delante:
                        xvel = 0.02F;
                        zvel = 0;
                        Rotation = new Vector3(0, 90, 0);
                        transform.Rotate(Rotation);
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
                }*/
        }
    }

    void LateUpdate()
    {
        camera.transform.position = this.transform.position + offset;
    }

}


