using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    private GameManager gameManager;
    private Transform target;

    public GameObject Manager;

    float speed = 5f, timer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
         if(timer <= 0){
            //PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector2 Direction = target.position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bulled"){
            Win();
        }    
    }

  
    
    private void Win(){Manager.GetComponent<Fishing>().Win();}
}
