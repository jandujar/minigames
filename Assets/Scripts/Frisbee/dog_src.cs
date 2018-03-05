using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_src : MonoBehaviour {

    //Private
    private bool isRunning;
    private bool isJumping;
    private bool hasLoose;
    private int maxDistanceToRun;
    private float volume;
    private float startTime;
    private float distanceTototalDistanceToDestination;
    private GameManager gameManager;
    private AudioSource source;

    //public
    public float runingSpeed;
    public GameObject endPosition;
    public GameObject winGameMeme;

    public AudioClip startSoundDog;
    public AudioClip startSoundHuman;
    public AudioClip winSound;
    public AudioClip looseSound;
    public AudioClip runningDog;
    public AudioClip jump;


    public void init(GameManager gm)
    {
        gameManager = gm;
    }


    void Start () {
        isRunning = false;
        isJumping = false;
        hasLoose = false;
        startTime = Time.time;
        distanceTototalDistanceToDestination = Vector3.Distance(transform.position, endPosition.transform.position);
        maxDistanceToRun = 340;
        volume = 1;
        source = GetComponent<AudioSource>();
    }

	void Update () {
        //InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)

        if (isRunning && !isJumping)
        {
            transform.Translate(runingSpeed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.A)) //el perro salta
        {
            isJumping = true;
            isRunning = false;
            endPosition.GetComponent<endPointRotation>().stopRun();
            PlayJump();
        }

        if (isJumping && !isRunning)
        {
            float currentDuration = (Time.time - startTime);
            float journeyFraction = currentDuration / distanceTototalDistanceToDestination;
            transform.position = Vector3.Lerp(transform.position, endPosition.transform.position, journeyFraction);
            if(Vector3.Distance(transform.position, endPosition.transform.position) <= 3)
            {
                isJumping = false;
            }
        }
       if(transform.position.x > maxDistanceToRun)
        {
            LooseGame();
        }
    }


    public void StartRun()
    {
        isRunning = true;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "frisbee")
        {
            WinGame();
        }
    }
    void WinGame()
    {
        Debug.Log("WIN");
        PlayWinSound();
        winGameMeme.transform.position = transform.position;
        winGameMeme.SetActive(true);
        if (!source.isPlaying)
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
        }
    }

    public void LooseGame()
    {
        if (!hasLoose)
        {
            Debug.Log("lose");
            StartCoroutine(playLooseClip());
            hasLoose = true;
        }
    }

    //******************************************************Sound Methods

    IEnumerator playLooseClip()
    {
        PlayLooseSound();
        yield return new WaitForSeconds(looseSound.length);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
    void PlayLooseSound()
    {
        source.Stop();
        source.clip = looseSound;
        source.Play();
        source.loop = false;
    }
    void PlayWinSound()
    {
        source.Stop();
        source.clip = winSound;
        source.Play();
        source.loop = false;
    }
   
    public void PlayStart()
    {
        StartCoroutine(playInitClips());
    }
    IEnumerator playInitClips()
    {
        source.Stop();
        source.clip = startSoundHuman;
        source.Play();
        yield return new WaitForSeconds(startSoundHuman.length);
        source.clip = startSoundDog;
        source.Play();
        yield return new WaitForSeconds(startSoundDog.length);
        source.clip = runningDog;
        source.Play();
        source.loop = true;
    }
    void PlayJump()
    {
        source.Stop();
        source.clip = jump;
        source.Play();
        source.loop = false;
    }
}


/*ToDO
    speedDogControlable o endpoint controlable
    Music
    Graphics
    */
