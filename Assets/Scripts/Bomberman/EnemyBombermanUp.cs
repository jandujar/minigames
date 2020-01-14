using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombermanUp : MonoBehaviour
{
    public float speed = 2;

    public int dir;

    bool win = false;
    public Bomberman game;

    public GameManager gameManager;
    
    void Start ()
    {
        dir = 1;
    }
    void Update()
    {   
        transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed * dir, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Walls"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Breakable"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Enemy"){
            dir*=-1;
        }
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            Win();
        }
        /*if(other.gameObject.tag == "Explosion"){
            Destroy(this.gameObject);
            Win();
        }*/
    }

    void Win(){
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }
}
