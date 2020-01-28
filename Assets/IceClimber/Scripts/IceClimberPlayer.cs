using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceClimberPlayer : MonoBehaviour
{

    private float move;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float foceJump = 4;
    private bool isGround;
    private bool canPieza = false;

    private Animator anim;
    private Rigidbody2D rgb;

    [SerializeField]
    private GameObject cam;

    private bool activeCam = false;

    private bool dead = false;
    private int counPos = 0;


    [SerializeField]
    private AudioClip jumpAudio;
    [SerializeField]
    private AudioClip cry;
    [SerializeField]
    private AudioClip lost;
    [SerializeField]
    private AudioClip item;
    private AudioSource source;
    [SerializeField]
    private IcePantalla pantalla;

    [SerializeField]
    private Text txt;
    [SerializeField]
    private GameObject canvas;

    GameManager gameManager = null;

    private bool start = false;


    public void init(GameManager gm)
    {
        gameManager = gm;
        this.gameManager = gm;
    }

    private float lastDir;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        isGround = true;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!dead && start){
            //if(!jump) move = InputManager.Instance.GetAxisHorizontal();
            move = InputManager.Instance.GetAxisHorizontal();

            if(pantalla.getTimer() <= 0){
                source.clip = cry;
                source.Play();
                dead = true;
                anim.SetBool("Cry", true);
                Invoke("Lose", 1f);
            }
        }

        
    }


    void FixedUpdate()
    {   
        if(!dead && start){
            if(move < -0.5f){
                transform.Translate(Vector3.left * -speed);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("Walk", true);
                lastDir = move;
            } else if(move > 0.5f){
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.right * speed);
                anim.SetBool("Walk", true);
                lastDir = move;
            } else {
                anim.SetBool("Walk", false);
            }

            if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4) && isGround){
                rgb.AddForce(Vector2.up * foceJump, ForceMode2D.Impulse);
                isGround = false;
                anim.SetBool("Jump", true);
                canPieza = true;
                activeCam = true;
                source.clip = jumpAudio;
                source.Play();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Pieza"){
            isGround = true;
            anim.SetBool("Jump", false);
        }

        if(other.gameObject.tag == "Paharo" || other.gameObject.tag == "Hielo"){
            
            source.clip = lost;
            source.Play();
            dead = true;
            anim.SetBool("Dead", true);
            Invoke("Lose", 1f);
        }

        if(other.gameObject.tag == "Fish"){
            source.clip = item;
            source.Play();
            txt.text = (int.Parse(txt.text)+100)+"";
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Apple"){
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Pieza"){
            isGround = true;
            anim.SetBool("Jump", false);
        }

        if(other.gameObject.tag == "Cam" && isGround && activeCam){
            activeCam = false;
            Destroy(other.gameObject);
            pantalla.doMove();
            counPos++;
            if(counPos == 6) canvas.SetActive(true);
        }


    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Pieza"){
            isGround = false;
        }
    }


    public float getHorizontal(){
        return lastDir;
    }

    public bool getCanPieza(){
        return canPieza;
    }

    public void setCanPieza(){
        canPieza = false;
    }

    public void startGame(){
        start = true;
    }

    private void Lose(){
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

}
