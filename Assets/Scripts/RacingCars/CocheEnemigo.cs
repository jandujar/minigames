using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheEnemigo : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private GameManager gameManager;

    public BoxCollider frenar;
    public BoxCollider giroIzq;
    public BoxCollider giroDer;

    public bool enableCar = false;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    void Update()
    {
        if (enableCar)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        if (frenar.Raycast(ray, out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }


}
