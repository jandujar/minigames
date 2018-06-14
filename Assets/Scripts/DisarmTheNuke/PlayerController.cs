using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool CanDisarmBomb;
    public bool isDisarmed;
    private bool isDamaged;
    private bool isCrouch;
    private bool InterpolateState;
    public int health;
    private float disarmTime;
    public float damageCooldownTimer;
    public float speed;
    public float sensitivity;
    public float jumpForce;
    private float moveFB;
    private float moveLR;
    private float rotationX;
    private float rotationY;
    private float verticalSpeed;
    private float damageCooldown;
    private float timeToIntrepolate;
    private float maxInterpolate;
    private float minInterpolate;
    public Camera Eyes;
    private Vector3 movement;
    private CharacterController PlayerCharacterController;
    public GUIStyle mystyle;
    public Texture hurtHUD;

    // Use this for initialization
    void Start () {
        PlayerCharacterController = GetComponent<CharacterController>();
        health = 100;
        isDamaged = false;
        damageCooldown = damageCooldownTimer;
        timeToIntrepolate = 0;
        minInterpolate = 0;
        maxInterpolate = 0.3f;
        disarmTime = 2.5f;
    }
	
	// Update is called once per frame
	void Update () {
        //checkInputs();

        move();
        if(isDamaged == true)
        {
            DamageCooldownTimer();
        }
	}


    void checkMovementInputs()
    {
        moveFB = InputManager.Instance.GetAxisVertical() * speed;//movement joystic
        moveLR = InputManager.Instance.GetAxisHorizontal() * speed;

        rotationX = InputManager.Instance.GetAxisHorizontal2() * sensitivity;//camera joystick
        rotationY = InputManager.Instance.GetAxisVertical2() * sensitivity;
        ApplyGravity();
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) && PlayerCharacterController.isGrounded) // (X playstation) for jump
        {
           // ApplyGravity();
            Jump();
        }
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2))//( O playstation) to crouch
        {
            if (!isCrouch)
            {
                Crouch();
            }else
            {
                PlayerCharacterController.height = PlayerCharacterController.height * 2;
                isCrouch = false;
            }
        }
        if (CanDisarmBomb)
        {
           DisarmBomb();
        }
        
    }

    void move()
    {
        checkMovementInputs();
        transform.Rotate(0, rotationX, 0);
        Eyes.transform.Rotate(-rotationY, 0, 0);
        movement = new Vector3(moveLR, verticalSpeed, moveFB);
        movement = transform.rotation * movement;
        PlayerCharacterController.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        verticalSpeed = jumpForce;

    }

    private void ApplyGravity()
    {
        if(PlayerCharacterController.isGrounded == true)
        {
            verticalSpeed = Physics.gravity.y;
        }else
        {
            verticalSpeed += Physics.gravity.y * Time.deltaTime * 4.9f;
            verticalSpeed = Mathf.Clamp(verticalSpeed, -50f, jumpForce);
        }
    }
    private void Crouch()
    {
        PlayerCharacterController.height = PlayerCharacterController.height / 2;
        isCrouch = true;
    }

    public void SetHealth(int damage)
    {
        if(isDamaged == false)
        {
            Debug.Log("playerhit");
            health = health - damage;
            isDamaged = true;
        } 
    }

    void DamageCooldownTimer()
    {
        if(damageCooldown < 0)
        {
            damageCooldown = damageCooldownTimer;
            isDamaged = false;
        }else 
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    void DisarmBomb()
    {
        
        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3)) //(Triangulo Playstation) desactivar
        {
            disarmTime -= Time.deltaTime;
            Debug.Log(disarmTime);
            //mover barrita
            if (disarmTime <= 0)
            {
                Debug.Log("isDisarmed");
                isDisarmed = true;
            }
        }
        else
        {
            disarmTime = 2.5f;
        }
    }
    private void OnGUI()
    {
        SetInterpolateTime();
        GUI.color = new Color(255, 0, 0, Mathf.Lerp(minInterpolate, maxInterpolate, timeToIntrepolate));
        timeToIntrepolate += 0.5f * Time.deltaTime;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hurtHUD, ScaleMode.StretchToFill, true);      

        if (timeToIntrepolate > 1f)
        {
            float temp = maxInterpolate;
            maxInterpolate = minInterpolate;
            minInterpolate = temp;
            timeToIntrepolate = 0;
        }
    }

    void SetInterpolateTime()
    {
        if (health > 80)
        {
            maxInterpolate = 0;
        }
        else if (health < 80 && health >= 60 && !InterpolateState)
        {
            minInterpolate = 0;
            maxInterpolate = 0.3f;
            InterpolateState = true;
        }
        else if(health < 60 && health >= 40 && InterpolateState)
        {
            minInterpolate = 0.3f;
            maxInterpolate = 0.6f;
            InterpolateState = false;
        }
        else if(health < 40 && !InterpolateState)
        {
            minInterpolate = 0.6f;
            maxInterpolate = 0.9f;
            InterpolateState = true;

        }
    }

}
