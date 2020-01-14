using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveGalaxian : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private GameManager gameManager;
    public GameObject[] points;
    public bool enableNave = false;

    int nextPoint = 0;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    void Update()
    {

    }

}
