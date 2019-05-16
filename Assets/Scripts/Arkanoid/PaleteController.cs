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
    public int ballSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f,Vector2.up.y * ballSpeed), ForceMode2D.Impulse);
        }
    }
}
