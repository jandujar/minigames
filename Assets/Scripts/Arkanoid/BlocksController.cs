using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class BlocksController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject powerUp1;
    private Vector3 actualPosition;
    private int RandomNumberPowerUp;
    public bool activateSound;
    
    private void Awake()
    {
       
        actualPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    // Start is called before the first frame update
    void Start()
    {
       
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV();

        activateSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Ball")
        {
            GameObject.Find("MusicContoller").GetComponent<AudioContollerArkaoid>().activateSound = true;
            gameObject.SetActive(false);
            GameObject.Find("GameController").GetComponent<GameContoller>().points += 10;
            GameObject.Find("GameController").GetComponent<GameContoller>().Score.text = "Score: " + GameObject.Find("GameController").GetComponent<GameContoller>().points.ToString();

            RandomNumberPowerUp = Random.Range(0, 3);
            switch (RandomNumberPowerUp)
            {
                case 0:
                    Instantiate(powerUp1, actualPosition, new Quaternion());
                    break;
                case 1:
                    
                    break;
                case 2:
                   
                    break;
                default:
                    break;
            }
        }
    }
}

