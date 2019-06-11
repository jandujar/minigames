using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaleteController : MonoBehaviour
{
    private float move;
    public float velocityX;
    private Vector3 ActualPosition;
    public float maxPositionX;
    public GameObject ball;
    public float ballSpeed;
    public bool activateBall;
    public bool followPale;
    public GameObject beginText;





    // Start is called before the first frame update
    void Start()
    {
        activateBall = true;
        followPale = true;

     
       
    }

    // Update is called once per frame
    void Update()
    {

        move = InputManager.Instance.GetAxisHorizontal();



        transform.Translate(move * velocityX * Time.deltaTime, 0, 0);



       if(transform.position.x > maxPositionX)
        {
            ActualPosition = new Vector3(maxPositionX, transform.position.y, transform.position.z);
            transform.position = ActualPosition;
            
        }

       if(transform.position.x < -maxPositionX)
        {
            ActualPosition = new Vector3(-maxPositionX, transform.position.y, transform.position.z);
            transform.position = ActualPosition;
           
        }

        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4) && activateBall == true)
        {
            followPale = false;
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,Vector2.up.y * ballSpeed * 75));
            beginText.SetActive(false);
            activateBall = false;
           
        }

        if(followPale == true)
        {
            ball.transform.position = new Vector3(transform.position.x , transform.position.y + 0.87f , transform.position.z);
           
       }

        if (IsInvoking() == false)
        {  
            maxPositionX = 18.61f;
        }
        else
        {
            maxPositionX = 15.11f;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.name == "PowerUp1(Clone)" && IsInvoking() == false)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * 2, this.transform.localScale.y, this.transform.localScale.z);
            Invoke("ScalePale", 2.0f);
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Ball")
        {
            Vector3 ContactPoint = col.contacts[0].point;
            Vector3 CenterPadle = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            float difference = CenterPadle.x - ContactPoint.x;

            if(ContactPoint.x < CenterPadle.x)
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(Mathf.Abs(250)), ballSpeed * 75));
            }else
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2((Mathf.Abs(250)), ballSpeed * 75));
            }

        }
    }

    void ScalePale()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y, this.transform.localScale.z);
    }

}
