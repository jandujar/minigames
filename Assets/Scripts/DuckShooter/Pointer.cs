﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private float moveVer;
    private float moveHor;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    private bool canShoot = false;
    private DuckShooter gameEnginge;
    private InputManager inputManager;

    void Awake()
    {
        gameEnginge = transform.Find("Game").GetComponent<DuckShooter>();
        inputManager = transform.Find("Game").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        canShoot = inputManager.GetButtonDown(0);


        //Pointer Movement
        moveVer = inputManager.GetAxisVertical();
        moveHor = inputManager.GetAxisHorizontal();

        transform.Translate(0, moveVer * vely * Time.deltaTime, 0);
        transform.Translate(moveHor * vely * Time.deltaTime, 0, 0);

        if (transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duck")
        {
            Debug.Log("Touched");
            if(canShoot)
            {
                Debug.Log("Shooted");
                other.GetComponent<Duck>().Death();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Duck")
        {
            Debug.Log("Touched");
            if (canShoot)
            {
                Debug.Log("Shooted");
                other.GetComponent<Duck>().Death();
                other.gameObject.GetComponent<Collider>().enabled = false;
                gameEnginge.DuckKilled();
            }
        }
    }
}