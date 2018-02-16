using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganPlayer : MonoBehaviour
{

    public bool enableGame;
    private GameManager gameManager;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableGame == true)
        {
            Time.timeScale = 0;
        }
    }
}
