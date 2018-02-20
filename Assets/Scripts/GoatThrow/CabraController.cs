using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]

public class CabraController : MonoBehaviour {

    public Image barra;
    public Text maxDisttext;
    public Text text;
    public Sprite idleSprite;

    public Sprite flySprite;

    public Transform initPos;

    public Transform directionSprite;

    public float maxDistance = 100;

    [Header("Audio")]
    public AudioClip goatScream;
    public AudioClip goatSplat;
    private AudioSource source;
    public bool canPlay;
    public bool splatCanPlay;

    [Header("Fuerza")]
    public float startForce = 80;
    public float maxForce = 100;
    public float incrementSpeed = 0;

    [Header("Angulo")]
    public float maxAngle = 60;
    public float minAngle = 0;
    public float angleSpeed = 1;

    Rigidbody2D rig;

    SpriteRenderer spr;

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
        source = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        canPlay = true;
        splatCanPlay = false;

        //maxDisttext.text ="Reach "+ maxDistance.ToString() + "m to win";
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
                    directionSprite.gameObject.SetActive(true);
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
            if (canPlay)
            {
                source.PlayOneShot(goatScream, .5f);
                canPlay = false;
            }
            
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
        directionSprite.Rotate(0, 0, angleSpeed * Time.deltaTime * multiply);
        if(multiply == 1)
        {
            if (directionSprite.rotation.eulerAngles.z > maxAngle)
            {
                multiply = -1;
            }
        }
        else
        {
             if (directionSprite.rotation.eulerAngles.z > 180 && directionSprite.rotation.eulerAngles.z < 360 - minAngle)
            {
                multiply = 1;
            }
        }
       

    }

    void Throw()
    {

        //Rig.AddForce(Direction * StartForce * potencia);

        rig.AddForce(directionSprite.right * (startForce + maxForce * foreCounter));
        foreCounter = 0;
        multiply = 1;
        barra.gameObject.SetActive(false);
        directionSprite.gameObject.SetActive(false);
        lastPosition = transform.position.x;
        flying = true;
        spr.sprite = flySprite;
        spawned = false;
        splatCanPlay = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameController"))
        {
            if (splatCanPlay)
            {
                source.PlayOneShot(goatSplat, .5f);
                splatCanPlay = false;
            }
            
            EndGame();
            //Spawn();
        }
    }

    void EndGame()
    {
        rig.velocity = new Vector2(0, 0);
        spr.sprite = idleSprite;
        flying = false;
        text.text = "You have reached "+ currentDistance.ToString("F2") + "m";
        StartCoroutine(StartNewScene());

    }
    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(3);
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
        maxDisttext.text = "Reach " + maxDistance.ToString() + "m to win";
        calcDir = false;
        calcForce = false;
        spawned = true;
        spr.sprite = idleSprite;
        currentDistance = 0;
        transform.position = initPos.position;
        rig.velocity = new Vector2(0, 0);
        barra.fillAmount = 0;
        barra.gameObject.SetActive(true);
        directionSprite.gameObject.SetActive(false);
    }

}
