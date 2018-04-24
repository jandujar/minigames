using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZombienite : MonoBehaviour {
    public float speed = 10f;
    public float gravity = 10f;
    public int totalHealth = 100;
    private int actualHealth;
    float jumpspeed = 10f;
    bool isGrounded = true;
    bool isDead = false;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    

    private int floorMask;
    public float camRayLength = 100f;

    //Delete this variable when I will do Jump Mechanic
    private bool blockJump = true;
    // Use this for initialization

    void Awake()
    {
        floorMask = LayerMask.GetMask("Water");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        anim.SetInteger("WeaponType_int", 2);
        anim.SetInteger("DeathType_int", 1);
        actualHealth = totalHealth;

    }
    
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = InputManager.Instance.GetAxisHorizontal();
        float v = InputManager.Instance.GetAxisVertical();

        if (actualHealth > 0)
        {


            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {            
                anim.SetBool("Shoot_b", true);
                anim.SetBool("FullAuto_b", true);
            }else
            {
                anim.SetBool("Shoot_b", false);
            }

            // Move the player around the scene.
            if (!blockJump)
            {
                Jumping();
            }
            
            Move(h, v);
        

            // Turn the player to face the mouse cursor.
            Turning();

        }
        else
        {
            isDead = true;
        }


        // Animate the player.
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);

        


        
    }

    void Turning()
    {
       // Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        transform.LookAt(new Vector3 (InputManager.Instance.GetAxisHorizontal2(), 0f, InputManager.Instance.GetAxisVertical2()));

     /*   RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotatation);
        }*/
    }

    void Jumping()
    {
        if (isGrounded && Input.GetKey("space"))
        {
            isGrounded = false;
            jumpspeed = 10;
        }


        if (!isGrounded)
        {
            if (jumpspeed >= 0.1f)
            {
                jumpspeed -= gravity * Time.deltaTime;
            }
            else
            {
                isGrounded = true;
            }

            transform.Translate(Vector3.up * jumpspeed * Time.deltaTime);
        }
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        // bool running = h != 0f || v != 0f;
        if (!isDead)
        {


            if (isGrounded && (h != 0 || v != 0))
            {
                anim.SetFloat("Speed_f", speed);

            }
            else
            {
                anim.SetFloat("Speed_f", 0f);
            }

            if (!isGrounded)
            {
                anim.SetBool("Jump_b", true);
            }
            else
            {
                anim.SetBool("Jump_b", false);
            }
        }else
        {
            anim.SetBool("Death_b", true);
        }
    }

    public void SetPlayerHealth(int damage)
    {
        actualHealth -= damage;
    }

    public int GetPlayerHealth()
    {
        return actualHealth;
    }

    public void SetPlayerIsDead(bool dead)
    {
        isDead = dead;
    }

    public bool GetPlayerIsDead()
    {
        return isDead;
    }

}
