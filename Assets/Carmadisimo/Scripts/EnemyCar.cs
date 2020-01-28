using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class EnemyCar : MonoBehaviour
{
    private Transform target;
    public float speed = 5;

    float Timer = 1f, TimerVelocity = 10f;

    Vector3 PlayerPos;

    public GameObject explosionPrefab;

    bool explosionExists;

    bool destroyExplosion = false;

    GameObject Explosion;

    public  AudioSource audioBoom;
    public CarMove carPlayer;

   

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioBoom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        Debug.Log("Speed: " + speed);

        //Chek the old position of the player
        Timer -= Time.deltaTime;
        if(Timer <= 0 && speed < 10f){
            Timer = 0.5f;
            PlayerPos = new Vector3(target.position.x, target.position.y, target.position.z);
        }
        if(speed >= 10f){
            Debug.Log("Stoy Mamadisimo");
            PlayerPos = new Vector3(target.position.x, target.position.y, target.position.z);
        }

        TimerVelocity -= Time.deltaTime;
        if(TimerVelocity <= 0){
            speed += 2.5f;            
            TimerVelocity = 10f;
        }

        transform.position = Vector3.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);
        transform.LookAt(target);                
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyCar(Clone)"){
            explosionExists = true;
            Explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            audioBoom.Play();
            carPlayer.scoreCarmadisimo += 10; 
            GameObject.Destroy(gameObject);
        }    
        if (other.gameObject.tag == "Wall"){
            explosionExists = true; 
            Explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); 
            audioBoom.Play();
            carPlayer.scoreCarmadisimo += 10; 
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
        }  
        if (other.gameObject.tag == "Explosion"){
            explosionExists = true;
            Explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            audioBoom.Play();
            carPlayer.scoreCarmadisimo += 10; 
            GameObject.Destroy(gameObject);
        }    
    }
}
