using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganPlayer : MonoBehaviour
{

    public bool enableGame = false;
    private GameManager gameManager;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableGame)
        {
            Time.timeScale = 0;
        }
    }
}
