using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    bool isPlayerDead = false;
    bool isDead = false;
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    Player player_SC;
    public int damage = 40;
    public int totalHealth = 100;
    private int actualHealth;
    public float animationSpeed;       //If this variable will change you have to change speed of NavMeshAgent  
    private Animator anim;
    private Collider collider;
    private Light light;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        actualHealth = totalHealth;
        light = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        anim.speed = animationSpeed;
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (!isDead && !isPlayerDead)
        {
            // ... set the destination of the nav mesh agent to the player.
            // NavMeshAgent.Warp(player.position);

            nav.SetDestination(player.position);

        }
        // Otherwise...
        else
        {
            
            if (isDead)
            {
                Debug.Log("Enemy Dead");
                // ... disable the nav mesh agent.
                light.enabled = true;
                nav.enabled = false;
                
                /*anim.enabled = false;
                collider.enabled = false;
                anim.speed = 0;*/
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerZombienite>().GetPlayerHealth() > 0)
            {
                Debug.Log("Herido");
                other.GetComponent<PlayerZombienite>().SetPlayerHealth(damage);
            }else
            {
                other.GetComponent<PlayerZombienite>().SetPlayerIsDead(true);
            }
        }
    }

    public void SetEnemyHealth(int damage)
    {
        actualHealth -= damage;
    }

    public int GetEnemyHealth()
    {
        return actualHealth;
    }

    public void SetEnemyIsDead(bool dead)
    {
        isDead = dead;
    }
}
