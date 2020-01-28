using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangSmolBall : MonoBehaviour
{
   private float forceX, forceY;
    public Rigidbody2D Ball;
    public bool goLeft, goRight;
    private GameObject ball1, ball2;
    private PangSmolBall pangBall;
    private float enemyCount;
    public GameManager gameManager;



    void Awake()
    {
        Ball = GetComponent<Rigidbody2D>();
        SetBallSpeed();
    }

    void Update()
    {
        moveBall();

        if (enemyCount == 0)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Smol Ball").Length;

        Debug.Log(enemyCount);
    }

    void moveBall() {
        if(goLeft){
            Vector3 temp = transform.position;
            temp.x -= forceX + Time.deltaTime;
            transform.position = temp;

        }
        else if(goRight){
            Vector3 temp = transform.position;
            temp.x += forceX + Time.deltaTime;
            transform.position = temp;
        }
    }

    void SetMoveLeft(bool canMoveLeft){
        this.goLeft = canMoveLeft;
        this.goRight = !canMoveLeft;
    }

    void SetMoveRight(bool canMoveRight){
        this.goRight = canMoveRight;
        this.goLeft = !canMoveRight;
    }

    void SetBallSpeed(){
        forceX = 0.0125f;
        
        switch(this.gameObject.tag){

            case "BigBall":
                forceY = 8f;
                break;

            case "Ball":
                forceY = 7.5f;
                break;

            case "SmallBall":
                forceY = 7f;
                break;

            case "LittleBall":
                forceY = 6.5f;
                break;
            case "SmolBall":
                forceY = 6f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground"){
            Ball.velocity = new Vector2(0, forceY);
        }
        if(other.gameObject.tag == "Right"){
            SetMoveRight(false);
        }
        if(other.gameObject.tag == "Left"){
            SetMoveLeft(false);
        }
        if(other.gameObject.tag == "Bullet"){
            Destroy(this.gameObject);
        }                 
    }
}
