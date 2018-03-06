using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : IMiniGame{
    [SerializeField] private GameManager gameManager;

    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposx = 14f;
    [SerializeField] private GameObject maceta; 
    [SerializeField] public int MacetaCount;
    [SerializeField] public int TryCount;
    [SerializeField] public bool win;
    [SerializeField] private AudioClip spawnSound;
    // Use this for initialization
    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        gameManager = gm;
        //throw new System.NotImplementedException();
    }

    public override void beginGame()
    {
        throw new System.NotImplementedException();
    }
    void Start () {
        MacetaCount = 3;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (TryCount <= 0)
        {
            Debug.Log("Fail");
            //lose
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        if (win)
        {
            Debug.Log("WIN");
            //win
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }

        move = InputManager.Instance.GetAxisHorizontal();
        
        transform.Translate( move * vely * Time.deltaTime,0, 0);

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
       while (MacetaCount > 0)
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Instantiate(maceta,this.transform.position, Quaternion.identity);
                MacetaCount--;
            }
        }
        
    }

    
}
