using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public GameObject camera;
    private Vector3 offset;
    float xvel, zvel;
    enum Direcciones { delante, izquierda, derecha, detras };
    private Direcciones direcciones;
    private Vector3 RotationSnake;
    private Vector3 RotationCamera;
    private int coins;
    public Snake_raul game;


    // Use this for initialization
    void Start () {
        zvel = 0f;
        xvel = 0.03f;
        offset = new Vector3(0,12,0);
        camera.transform.eulerAngles = new Vector3(90, 0, 0);
        direcciones = Direcciones.delante;
        coins = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "coin")
        {
            Debug.Log("Has cogido una moneda");
            Debug.Log("tienes"+ coins);
            other.gameObject.SetActive(false);
            coins++;
        }

        if (other.gameObject.name == "muerte")
        {
            Debug.Log("You are dead");
            game.EndGame(false);
        }
    }

    void Update () {

        if (coins == 20)
        {
            Debug.Log("Win");
            game.EndGame(true);
        }
        transform.Translate(zvel, 0f, xvel);

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Debug.Log("izq");
                //xvel = 0.02F;
                //zvel = 0;
                RotationSnake = new Vector3(0, -90, 0);
                transform.Rotate(RotationSnake);
                //RotationCamera = new Vector3(0, -90, 0);
                //camera.transform.Rotate(RotationCamera);
                
        /*switch (direcciones)
         {
             case Direcciones.delante:
                    // camera.transform.Rotate(0, -90, 0);
                    camera.transform.eulerAngles = new Vector3(90, -90, 0);
                    //offset = new Vector3(4, 1.2f, 0);
                    direcciones = Direcciones.izquierda;
                 break;
             case Direcciones.izquierda:
                    // camera.transform.Rotate(0,-90,0);
                    camera.transform.eulerAngles = new Vector3(90, -180, 0);
                    //offset = new Vector3(0, 1.2f, 4);
                direcciones = Direcciones.detras;
                 break;
             case Direcciones.detras:
                    // camera.transform.Rotate(0, -90, 0);
                    camera.transform.eulerAngles = new Vector3(90, 90, 0);
                    //offset = new Vector3(-4, 1.2f, 0);
                    direcciones = Direcciones.derecha;
                 break;
             case Direcciones.derecha:
                    //camera.transform.Rotate(0, -90, 0);
                    camera.transform.eulerAngles = new Vector3(90, 0, 0);
                    //offset = new Vector3(0, 1.2f, -4);
                    direcciones = Direcciones.delante;
                 break;
             default:
                 break;
         }*/
    }

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))
            {
                Debug.Log("der");
            //xvel = 0.02F;
            //zvel = 0;
            RotationSnake = new Vector3(0, 90, 0);
            transform.Rotate(RotationSnake);
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


