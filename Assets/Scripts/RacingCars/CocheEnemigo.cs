using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheEnemigo : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private GameManager gameManager;
    public GameObject[] points;
    public bool enableCar = false;

    int nextPoint = 0;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    void Update()
    {
        if (enableCar)
        {
            moveToNextPosition();
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
            Debug.Log(nextPoint);
        }
    }

    void moveToNextPosition()
    {
        transform.LookAt(points[nextPoint].transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (nextPoint + 1 != points.Length)
        {
            nextPoint++;
        }
    }
}
