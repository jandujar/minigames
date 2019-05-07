using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleShooterEngine : IMiniGame
{

    [SerializeField] Camera MainCamera;
    [SerializeField] GameManager gameManagerInstance;
    [SerializeField] GameObject Projectile;

 

    public bool cannotShootAnymore = true;

    [SerializeField] Animator ArrowAnimator;

    private float maxTimeTimer = 10f;
    private float tempTimer = 0.0f;


    [Range(0, 100)]
    public float force;

    public override void beginGame()
    {
        gameObject.GetComponent<CameraRotation>().enabled = true;
        cannotShootAnymore = false;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gm = gameManagerInstance;
        tempTimer = maxTimeTimer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!cannotShootAnymore) { 


            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {

                GameObject arrowShoot = Instantiate(Projectile, MainCamera.transform.GetChild(1).transform.position, MainCamera.transform.rotation);
                Rigidbody rb = arrowShoot.GetComponent<Rigidbody>();
                rb.velocity = MainCamera.transform.forward * force;
                cannotShootAnymore = true;
            
            }

        }


    }

    public void WinGame()
    {
            gameManagerInstance.EndGame(MiniGameResult.WIN);
    }

    public void LoseGame()
    {

            gameManagerInstance.EndGame(MiniGameResult.LOSE);
    }


}
