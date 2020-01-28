using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public GameManager gameManager;
    private float moveH, moveV;
    
    public float speed = 6.0F, gravity = 20F, rotateSpeed = 6F, TimeToSpawn = 5f, TimeToPower = 10f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject enemyCarPrefab;
    public GameObject bombPrefab;
    //Spawn
    float spawnXPoint, spawnZPoint;
    public float maxXPoint = 20f, maxZPoint = 20f;

    public float minXPoint = 10f, minZPoint = 10f;

    bool isCarmadisimo = false;

    float nitro = 0;

    public Slider Nitro;

    public int scoreCarmadisimo;

    public Text scoreText;

    bool playing = false;

    public void InitGame(GameManager gm){
        
        gameManager = gm;
        playing = true;
    }

    void FixedUpdate(){

        if(!playing){return;}

        //Inputs
        CharacterController controller = GetComponent<CharacterController>();
        
        moveH = InputManager.Instance.GetAxisHorizontal();
        moveV = InputManager.Instance.GetAxisVertical();

        //Direction whith Vertical Input
        moveDirection = new Vector3(0, 0, moveV);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, moveH* rotateSpeed, 0);

        if(Input.GetKey("space") && isCarmadisimo){
            if(nitro > 0){
                speed = 12f;
                nitro --;
                Nitro.value -= 0.005f;
            }
            else{
                isCarmadisimo = false;
            }
            
        }else{
            speed = 6f;
        }
        

        //Spawn Enemys
        TimeToSpawn -= Time.deltaTime;
        if(TimeToSpawn <= 0){
            SpawnEnemy();
            TimeToSpawn = 2f;  
            scoreCarmadisimo += 10;           
        }
        //Spawn Nitro
        TimeToPower -= Time.fixedDeltaTime;
        if(TimeToPower <= 0){
            SpawnPowerUp();
            TimeToPower = 10f;
        }
        
        scoreText.text = scoreCarmadisimo.ToString();

    }
    void SpawnEnemy(){
        //RandomizeIt
        int Randomize = Random.Range(1, 4);

        switch(Randomize){
            case 1:
                spawnXPoint = Random.Range(0.0f, maxXPoint);
                if(spawnXPoint < minXPoint){
                    spawnZPoint = Random.Range(minXPoint, maxZPoint);
                }
                else{
                    spawnZPoint = Random.Range(0.0f, maxZPoint);
                }
                break;
            case 2:
                spawnXPoint = Random.Range(0.0f, maxXPoint);
                if(spawnXPoint < minXPoint){
                    spawnZPoint = Random.Range(-minZPoint, -maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, -maxZPoint);
                }   
                break;
            case 3:
                spawnXPoint = Random.Range(0.0f, -maxXPoint);
                if(spawnXPoint > -minXPoint){
                    spawnZPoint = Random.Range(-minXPoint, -maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, -maxZPoint);
                }
                break;
            case 4:
                spawnXPoint = Random.Range(0.0f, -maxXPoint);
                if(spawnXPoint > -minXPoint){
                    spawnZPoint = Random.Range(minXPoint, maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, maxZPoint);
                }
            break;
        }
        //Spawn Enemy
        Vector3 spawnPoint = new Vector3(transform.position.x +spawnXPoint, transform.position.y, transform.position.z + spawnZPoint);
        GameObject EnemyCar = Instantiate(enemyCarPrefab, spawnPoint, transform.rotation);
        EnemyCar.GetComponent<EnemyCar>().carPlayer = this;
    }

    void SpawnPowerUp(){
        //RandomizeIt
        int Randomize = Random.Range(1, 4);

        switch(Randomize){
            case 1:
                spawnXPoint = Random.Range(0.0f, maxXPoint);
                if(spawnXPoint < minXPoint){
                    spawnZPoint = Random.Range(minXPoint, maxZPoint);
                }
                else{
                    spawnZPoint = Random.Range(0.0f, maxZPoint);
                }
                break;
            case 2:
                spawnXPoint = Random.Range(0.0f, maxXPoint);
                if(spawnXPoint < minXPoint){
                    spawnZPoint = Random.Range(-minZPoint, -maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, -maxZPoint);
                }   
                break;
            case 3:
                spawnXPoint = Random.Range(0.0f, -maxXPoint);
                if(spawnXPoint > -minXPoint){
                    spawnZPoint = Random.Range(-minXPoint, -maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, -maxZPoint);
                }
                break;
            case 4:
                spawnXPoint = Random.Range(0.0f, -maxXPoint);
                if(spawnXPoint > -minXPoint){
                    spawnZPoint = Random.Range(minXPoint, maxZPoint);
                }
                else{
                   spawnZPoint = Random.Range(0.0f, maxZPoint);
                }
            break;
        }
        //Spawn Power Up
        Vector3 spawnPoint = new Vector3(transform.position.x +spawnXPoint, transform.position.y, transform.position.z + spawnZPoint);
        GameObject PowerBomb = Instantiate(bombPrefab, spawnPoint, transform.rotation);
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy"){
            Lose();
        } 
        if (other.gameObject.tag == "Goal"){
            Debug.Log("BOOM!!");
            GameObject.Destroy(other.gameObject);
            isCarmadisimo = true;
            nitro = 200;
            Nitro.value = 1;
            scoreCarmadisimo += 10;
        }
        
    }
    void Win(){
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);         
    }
    void Lose(){
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);            
    }
}
