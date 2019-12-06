using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheEnemigo : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private GameManager gameManager;

    public bool enableCar = false;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    void Start()
    {

    }

    void Update()
    {
        if (enableCar)
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
    }
}
