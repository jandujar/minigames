using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangBullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    public GameManager gameManager;
    public float speed = 5f;

    private static float winCounter = 0f;
    void Awake() {
        bullet = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(winCounter == 29){
            Debug.Log("win counter es igual a 30");
            Win();
        }
        
    }

    void FixedUpdate()
    {
        bullet.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Top"){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Big Ball"){
            Destroy(gameObject);
        }

        string[] name = other.name.Split();

        if(name.Length > 1){
            if(name[1] == "Ball"){
                winCounter++;
                Debug.Log("Win counter: "  + winCounter);
                Destroy(this.gameObject);
                
            }
            
        }
        
    }

    void Win(){
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }
}
