using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    Vector2 movement;

    bool lose = false;
    public GameObject bullet;

    public bool ableToShoot = true;
    float shootCounter = 50f;

    public GameManager gameManager;



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if(ableToShoot && Input.GetKeyDown(KeyCode.Space)){
            shootCounter = 50f;
            Shoot();
        }      
        if(!ableToShoot){
            shootCounter--;
        }
        if(shootCounter <= 0){
            ableToShoot = true;
        }
        //Debug.Log(shootCounter);
        
    }

    void Shoot() {
        if(ableToShoot){
            ShootTheBullet();
        }
        ableToShoot = false;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void ShootTheBullet(){

        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        playerPosition.y += 0.5f;

        Instantiate(bullet, playerPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string[] name = other.name.Split();

        if(name.Length > 1){
            if(name[1] == "Ball"){
                Destroy(this.gameObject);
                losing();
            }
            
        }
        if(other.gameObject.tag == "Big Ball"){
            Destroy(this.gameObject);
        }

    }

    public void losing () {
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
}
