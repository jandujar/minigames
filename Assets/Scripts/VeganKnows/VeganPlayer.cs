using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganPlayer : MonoBehaviour {

    public Vector2 movement;
    public bool enableBall = false;
    private GameManager gameManager;
    public float maxVelocity = 10;


    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableBall)
        {
            transform.Translate(movement.x * Time.deltaTime, movement.y * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                movement.x *= -2f;
                break;
            case "GameController":
                movement.y *= -1.25f;
                break;
            case "Finish":
                movement.x = 0;
                movement.y = 0;
                gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
                break;
            case "Respawn":
                movement.x = 0;
                movement.y = 0;
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
                break;
        }

        if (movement.x > maxVelocity)
        {
            movement.x = maxVelocity;
        }
        if (movement.x < -maxVelocity)
        {
            movement.x = -maxVelocity;
        }
        if (movement.y > maxVelocity)
        {
            movement.y = maxVelocity;
        }
        if (movement.y < -maxVelocity)
        {
            movement.y = -maxVelocity;
        }
    }
}
