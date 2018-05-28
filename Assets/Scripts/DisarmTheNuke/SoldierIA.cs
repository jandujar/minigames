using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIA : MonoBehaviour {


    public int health;
    private int damage;
    private bool statePassive;
    private bool stateAggressive;
    private bool stateDefensive;
    private bool triggerL;
    private bool triggerR;
    private bool triggerM;
    private bool cover;
    private bool isDamaged;
    private bool isDead;
    public Transform wallPosition;
    public Transform buildingPosition;
    public Transform triggerLPosition;
    public Transform playerSoldier;
    public Transform shootPoint;
    public Animator animator;
    private float speed;
    private float speedBack;
    private float walk;
    private float walkBack;
    private float range;
    private float damageCooldown;
    public float damageCooldownTimer;
    static string playerPosition;
    public AudioClip FireShoot;
    private AudioSource audiosource;
    public SkinnedMeshRenderer mesh;

    //animator.SetBool("MeleeAttack", false);
    // Use this for initialization
    void Start () {
        health = 100;
       damage = 15;
        range = 160;
       speed = 20f;
       speedBack = 16f;

        cover = false;
        statePassive = true;
        triggerL = false;
        triggerR = false;
        triggerM = false;
        playerPosition = null;
        isDamaged = false;
        damageCooldown = damageCooldownTimer;
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = FireShoot;
    }
	
	void Update () {
        if(health <= 0)
        {
            dead();
            return;
        }
        DamageCooldownTimer();
        if (health == 100 && !triggerL && !triggerR && !triggerM)
        {
            statePassive = true;
            stateAggressive = false;
            stateDefensive = false;
        }
        if (health <= 100 && triggerR || health < 100 && !triggerL)
        {
            statePassive = false;
            stateAggressive = false;
            stateDefensive = true;
        }
        if (health > 20 && triggerL && !stateDefensive|| health < 20 && triggerM)
        {
            statePassive = false;
            stateAggressive = true;
            stateDefensive = false;
        }
        walk = speed * Time.deltaTime;
        walkBack = speedBack * Time.deltaTime;

        SetState();
    }

    void SetState()
    {
        if (stateDefensive)
        {
            Defensive();
        }
        if (stateAggressive)
        {
            Agressive();
        }
    }

    void Defensive()
    {
        if(playerPosition == "triggerR" && health > 20)
        {
            transform.LookAt(playerSoldier);
            if (!cover)
            {
                transform.position = Vector3.MoveTowards(transform.position, wallPosition.position, walk);
                animator.SetBool("isRuning", true);
                if (transform.position == wallPosition.position)
                {
                    cover = true;
                }
            }else if (cover)
            {
                animator.SetBool("isShooting", true);
                Fire();
            }
        }
        else if (playerPosition == "triggerM" || playerPosition == null)
        {
            transform.LookAt(playerSoldier);
            transform.position = Vector3.MoveTowards(transform.position, buildingPosition.position, walkBack);
            
            if (transform.position == buildingPosition.position)
            {
                animator.SetBool("isRuning", false);
                animator.SetBool("isShooting", true);
            }else
            {
                animator.SetBool("isRuning", true);
                animator.SetBool("isShooting", false);
            }
            Fire();
        }
    }
    void Agressive()
    {
        if (playerPosition == "triggerL" || playerPosition == "triggerM")
        {
            transform.LookAt(playerSoldier);
            animator.SetBool("isShooting", true);
            Fire();
        }
    }

    public void setTriggers(string trigger)
    {
        switch (trigger)
        {
            case "triggerL":
                //Debug.Log("triggerL");
                triggerL = true;
                triggerR = false;
                triggerM = false;
                playerPosition = "triggerL";
                break;
            case "triggerM":
                Debug.Log("triggerM");
                triggerL = false;
                triggerR = false;
                triggerM = true;
                playerPosition = "triggerM";
                break;
            case "triggerR":
               // Debug.Log("triggerR");
                triggerL = false;
                triggerR = true;
                triggerM = false;
                playerPosition = "triggerR";
                break;
        }
    }

    public void SetHealth(int damage)
    {
        
            health = health - damage;
            Debug.Log(health + "enemy HP");
    }

    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.up, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Player")
            {
                if (!isDamaged)
                {
                    if (!audiosource.isPlaying) { 

                    audiosource.Play();
                    }
                    if (acuracy())
                    {
                        isDamaged = true;
                        Debug.Log("hit the player" + hit.transform.GetComponent<PlayerController>().health);
                        hit.transform.GetComponent<PlayerController>().SetHealth(damage);
                    }
                }
            }
        }
    }

    void DamageCooldownTimer()
    {
        if (!isDamaged)
        {
            return;
        }
        if (damageCooldown < 0)
        {
            damageCooldown = damageCooldownTimer;
            isDamaged = false;
        }
        else
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    bool acuracy()
    {
        int rand;
        rand = Random.Range(0, 10);
        if (rand < 1)
        {
            Debug.Log("hitTrue");
            return true;
        }else
        {
            Debug.Log("hitFalse");
            return false;
        }
    }

    void dead()
    {
        if (!isDead)
        {
            mesh.enabled = false;
            Destroy(this);
            isDead = true;
        }
        
    }
}