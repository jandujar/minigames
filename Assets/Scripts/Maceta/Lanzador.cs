using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour{
    

    private float move;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposx = 14f;
    public GameObject maceta; 
    public int TryCount;
   
    [SerializeField] private AudioClip spawnSound;

    public bool Failed;
    public bool win;
    // Use this for initialization
    
    void Start () {
        //TryCount = 3;
        Failed = false;
        win = false;
    }
	 public void setWin(bool input)
    {
        win = input;
    }

	// Update is called once per frame
	void Update () {
        
        if (TryCount <= 0)
        {
            Debug.Log("Fail");
           
        }
        if (win)
        {
            Debug.Log("WIN");
           
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

        if (TryCount > 0)
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
                {
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    GameObject Mmaceta=Instantiate(maceta,this.transform.position, Quaternion.identity);
                    Maceta macetascript;
                    macetascript = Mmaceta.GetComponentInChildren<Maceta>();
                    if (macetascript.GetComponent<Maceta>().WIN == true)
                    {
                        Debug.Log("hitted, win");
                        win=true;
                    }
                    TryCount--;
                }
        }

        if (TryCount <= 0)
        {
            Failed = true;
        }   
    }
   
    
}
