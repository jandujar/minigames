using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class snakeMovement : MonoBehaviour {

    public float Speed;
    public float RotationSpeed;

    public AudioSource coinsound ;
    

    public Text score;
    public int coins = 0;

    public GameManager gameManager;

    public GameObject[] tailObject = new GameObject[1];

    public float z_offset = -0.5f;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;
    public GameObject coin9;
    public GameObject coin10;
    public GameObject coin11;
    public GameObject coin12;
    public GameObject coin13;
    public GameObject coin14;
    public GameObject coin15;
    public GameObject coin16;
    public GameObject coin17;
    public GameObject coin18;
    public GameObject coin19;
    public GameObject coin20;

    public GameObject snakeBody2;
    public GameObject snakeBody3;
    public GameObject snakeBody4;
    public GameObject snakeBody5;
    public GameObject snakeBody6;
    public GameObject snakeBody7;
    public GameObject snakeBody8;
    public GameObject snakeBody9;
    public GameObject snakeBody10;
    public GameObject snakeBody11;
    public GameObject snakeBody12;
    public GameObject snakeBody13;
    public GameObject snakeBody14;
    public GameObject snakeBody15;
    public GameObject snakeBody16;
    public GameObject snakeBody17;
    public GameObject snakeBody18;
    public GameObject snakeBody19;
    public GameObject snakeBody20;
    

    // Use this for initialization
    void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        score.text = coins.ToString();


        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1 * RotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))

        {
            Debug.Log("se acabo");
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
            
        }

        if (other.CompareTag("1"))

        {
            Debug.Log("hola");
            coin1.gameObject.SetActive(false);
            coin2.gameObject.SetActive(true);
            snakeBody2.SetActive(true);
            coins += 1;


            coinsound.Play();
            
        }
        if (other.CompareTag("2"))

        {
            Debug.Log("hola");
            coin2.gameObject.SetActive(false);
            coin3.gameObject.SetActive(true);
            snakeBody3.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("3"))

        {
            Debug.Log("hola");
            coin3.gameObject.SetActive(false);
            coin4.gameObject.SetActive(true);
            snakeBody4.SetActive(true);
            coins += 1;

        }

        if (other.CompareTag("4"))

        {
            Debug.Log("hola");
            coin4.gameObject.SetActive(false);
            coin5.gameObject.SetActive(true);
            snakeBody5.SetActive(true);
            coins += 1;
        }

        if (other.CompareTag("5"))

        {
            Debug.Log("hola");
            coin5.gameObject.SetActive(false);
            coin6.gameObject.SetActive(true);
            snakeBody6.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("6"))

        {
            Debug.Log("hola");
            coin6.gameObject.SetActive(false);
            coin7.gameObject.SetActive(true);
            snakeBody7.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("7"))

        {
            Debug.Log("hola");
            coin7.gameObject.SetActive(false);
            coin8.gameObject.SetActive(true);
            snakeBody8.SetActive(true);
            coins += 1;

        }
        if (other.CompareTag("8"))

        {
            Debug.Log("hola");
            coin8.gameObject.SetActive(false);
            coin9.gameObject.SetActive(true);
            snakeBody9.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("9"))

        {
            Debug.Log("hola");
            coin9.gameObject.SetActive(false);
            coin10.gameObject.SetActive(true);
            snakeBody10.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("10"))

        {
            Debug.Log("hola");
            coin10.gameObject.SetActive(false);
            coin11.gameObject.SetActive(true);
            snakeBody11.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("11"))

        {
            Debug.Log("hola");
            coin11.gameObject.SetActive(false);
            coin12.gameObject.SetActive(true);
            snakeBody12.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("12"))

        {
            Debug.Log("hola");
            coin12.gameObject.SetActive(false);
            coin13.gameObject.SetActive(true);
            snakeBody13.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("13"))

        {
            Debug.Log("hola");
            coin13.gameObject.SetActive(false);
            coin14.gameObject.SetActive(true);
            snakeBody14.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("14"))

        {
            Debug.Log("hola");
            coin14.gameObject.SetActive(false);
            coin15.gameObject.SetActive(true);
            snakeBody15.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("15"))

        {
            Debug.Log("hola");
            coin15.gameObject.SetActive(false);
            coin16.gameObject.SetActive(true);
            snakeBody16.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("16"))

        {
            Debug.Log("hola");
            coin16.gameObject.SetActive(false);
            coin17.gameObject.SetActive(true);
            snakeBody17.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("17"))

        {
            Debug.Log("hola");
            coin17.gameObject.SetActive(false);
            coin18.gameObject.SetActive(true);
            snakeBody18.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("18"))

        {
            Debug.Log("hola");
            coin18.gameObject.SetActive(false);
            coin19.gameObject.SetActive(true);
            snakeBody19.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("19"))

        {
            Debug.Log("hola");
            coin19.gameObject.SetActive(false);
            coin20.gameObject.SetActive(true);
            snakeBody20.SetActive(true);
            coins += 1;
        }
        if (other.CompareTag("20"))

        {
            Debug.Log("hola");
            coins += 1;
            coin20.gameObject.SetActive(false);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);


        }
    }


   
}

