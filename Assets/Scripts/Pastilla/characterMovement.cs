using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour {
    [SerializeField]
    float characterVelocity;
    [SerializeField]
    float rotationVelocity;
    [SerializeField]
    float jumpForce;
    Vector3 translationVector;
    Rigidbody _rigidbody;
    float rotation;
    float velocity;
    bool jump;
    [SerializeField]
    private GameManager gameManager;
    public AudioSource Audio;
    public AudioClip clip;
    void checkInputs()
    {        
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)
        {
            //velocity = Input.GetAxis("Vertical") * characterVelocity;
            velocity = InputManager.Instance.GetAxisVertical() * characterVelocity;
            velocity *= Time.deltaTime;
            //Debug.Log(transform.forward);
            translationVector += transform.forward * Input.GetAxis("Vertical") * characterVelocity;
        }
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f)
        {
            //rotation = Input.GetAxis("Horizontal") * rotationVelocity;
            rotation = InputManager.Instance.GetAxisHorizontal();
            rotation *= Time.deltaTime;
            if(rotation > 0.0f)
           transform.Rotate(transform.up * rotationVelocity);// Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(Vector3.Cross(transform.forward, transform.up) * Input.GetAxis("Horizontal") * rotationVelocity),Time.deltaTime);
            else
                transform.Rotate(-transform.up * rotationVelocity);
        }
       
        if((Input.GetKeyDown(KeyCode.Space) || InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) && !jump)
        {
            Audio.clip = clip;
            Audio.Play();
            _rigidbody.AddForce(Vector3.up * jumpForce*100);
            jump = true;
        }
     
    }
    void applyForces()
    {
       
        //transform.forward = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)    //forward direction
        {
            _rigidbody.AddForce(transform.forward * Input.GetAxis("Vertical") * characterVelocity);
        }
        else
        {
          //  _rigidbody.AddForce(-_rigidbody.velocity);
            translationVector = Vector3.zero;
        }
        _rigidbody.velocity = new Vector3(
            Mathf.Clamp(_rigidbody.velocity.x, -characterVelocity, characterVelocity), 
            Mathf.Clamp(_rigidbody.velocity.y, -characterVelocity, characterVelocity),
            Mathf.Clamp(_rigidbody.velocity.z, -characterVelocity, characterVelocity));
        translationVector = new Vector3(Mathf.Clamp(-characterVelocity, translationVector.x, characterVelocity),
            0.0f,
            Mathf.Clamp(translationVector.z, -characterVelocity, characterVelocity));
    }
	// Use this for initialization
	void Start () {
        translationVector = Vector3.zero;
        _rigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
      
       checkInputs();
        applyForces();
        Debug.DrawRay(transform.position, transform.forward,Color.red,1.0f);
      /*  float h = characterVelocity * Input.GetAxis("Mouse X");
        
        transform.Rotate(0, h, 0);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plataforma")
        {
            transform.parent = collision.transform;
        }     
        else if(collision.gameObject.name == "Pacman")
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        else if (collision.gameObject.name == "Final")
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
        jump = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        transform.parent = null;
    }
}
