using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangBall : MonoBehaviour
{
    private float forceX, forceY;
    public Rigidbody2D Ball;
    public bool goLeft, goRight;
    private GameObject ball1, ball2;
    private PangBall pangBall1, pangBall2;
    public GameObject originalBall;

    void Awake()
    {
        Ball = GetComponent<Rigidbody2D>();
        SetBallSpeed();
    }

    void Update()
    {
        moveBall();
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

    void InstantiateBalls(){
        if(this.gameObject.tag != "SmolBall"){

            ball1 = Instantiate(originalBall);
            ball2 = Instantiate(originalBall);
            
            ball1.name = originalBall.name;
            ball2.name = originalBall.name;

            pangBall1 = ball1.GetComponent<PangBall>();
            pangBall2 = ball2.GetComponent<PangBall>();
        }
    }

    void InitializeBallsAndTurnOffCurrentBall(){

        //if(gameObject.tag != "Smol Ball"){
            InstantiateBalls();

            Vector3 temp = transform.position;

            ball1.transform.position = temp;
            pangBall1.SetMoveLeft ( false );

            ball2.transform.position = temp;
            pangBall2.SetMoveRight ( false );

            ball1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
            ball2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);

            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        /*}
             
        if(gameObject.tag == "Smol Ball"){
            gameObject.SetActive(false);
        }*/
           
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
            if(other.gameObject.tag != "SmolBall"){
                InitializeBallsAndTurnOffCurrentBall();
            }else{
                //gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }     
    }
}
