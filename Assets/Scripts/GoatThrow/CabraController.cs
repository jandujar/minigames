using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabraController : MonoBehaviour {

    public Image barra;
    public Text maxDisttext;
    public Text text;
    public Sprite IdleSprite;

    public Sprite FlySprite;

    public Transform InitPos;

    public Transform DirectionSprite;

    public float maxDistance = 100;
    [Header("Fuerza")]
    public float StartForce = 80;

    public float MaxForce = 100;
    public float incrementSpeed = 0;
    [Header("Angulo")]
    public float MaxAngle = 60;
    public float MinAngle = 0;
    
    public float angleSpeed = 1;

    Rigidbody2D Rig;

    SpriteRenderer SPR;

     float foreCounter = 0;
   // public float potencia = 0;

    

     bool calcForce = false;

     bool calcDir = false;

     int multiply = 1;




    GameManager gameManager;

    private float currentDistance = 0;
    
     bool flying = false;
    private float lastPosition = 0;
    bool spawned = false;
    public void OnEnable()
    {
        Spawn();
    }
    public void init(GameManager gm)
    {

        gameManager = gm;
        Rig = GetComponent<Rigidbody2D>();
        SPR = GetComponent<SpriteRenderer>();
        maxDisttext.text = maxDistance.ToString() + "m";
    }
	// Update is called once per frame
	void Update () {
        if (spawned)
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                if (!calcForce)
                {
                    calcForce = true;
                }
                else if(!calcDir)
                {
                    DirectionSprite.gameObject.SetActive(true);
                    calcDir = true;
                    multiply = 1;
                }
                else
                {
                    Throw();
                }

            }
            else
            {

                if (calcForce && !calcDir)
                {
                    IncrementForce();
                }
                else if(calcDir)
                {
                    IncrementDirection();
                }

            }

        }
        if (flying)
        {
            currentDistance += transform.position.x - lastPosition;
            lastPosition = transform.position.x;
        }
	}

    void IncrementForce()
    {
        
        foreCounter = foreCounter + Time.deltaTime * incrementSpeed * multiply;
        // potencia = animCurve.Evaluate(foreCounter);
        //barra.fillAmount = potencia;
        barra.fillAmount = foreCounter;
        if (foreCounter >= 1)
        {
            multiply = -1;
        }
        else if (foreCounter <= 0)
        {
            multiply = 1;
        }
    }

    void IncrementDirection()
    {
        DirectionSprite.Rotate(0, 0, angleSpeed * Time.deltaTime * multiply);
        if(multiply == 1)
        {
            if (DirectionSprite.rotation.eulerAngles.z > MaxAngle)
            {
                multiply = -1;
            }
        }
        else
        {
             if (DirectionSprite.rotation.eulerAngles.z > 180 && DirectionSprite.rotation.eulerAngles.z < 360 - MinAngle)
            {
                multiply = 1;
            }
        }
       

    }

    void Throw()
    {

        //Rig.AddForce(Direction * StartForce * potencia);

        Rig.AddForce(DirectionSprite.right * (StartForce + MaxForce * foreCounter));
        foreCounter = 0;
        multiply = 1;
        barra.gameObject.SetActive(false);
        DirectionSprite.gameObject.SetActive(false);
        lastPosition = transform.position.x;
        flying = true;
        SPR.sprite = FlySprite;
        spawned = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            EndGame();
            //Spawn();
        }
    }

    void EndGame()
    {
        Rig.velocity = new Vector2(0, 0);
        SPR.sprite = IdleSprite;
        flying = false;
        text.text = "Has hecho: "+ currentDistance.ToString("F2") + "m";
        StartCoroutine(StartNewScene());

    }
    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(5);
        if (currentDistance < maxDistance)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        else
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }


    void Spawn()
    {
        calcDir = false;
        calcForce = false;
        spawned = true;
        SPR.sprite = IdleSprite;
        currentDistance = 0;
        transform.position = InitPos.position;
        Rig.velocity = new Vector2(0, 0);
        barra.fillAmount = 0;
        barra.gameObject.SetActive(true);
        DirectionSprite.gameObject.SetActive(false);
    }

}
