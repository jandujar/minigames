using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark : MonoBehaviour
{
    private float moveVer;
    private float moveHor;
    public float vely = 5;
    private Vector3 tmpPosition;
    public float maxposy = 5.9f;
    public float maxposx = 10f;
    public bool canShoot = false;
    public bool enableShot = true;
    public AudioClip playerShoot;
    private AudioSource source;

    private GameManager Gm;

    public int puntuation = 0;

    public Text myText;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (puntuation >= 3) {
            myText.text = "WIN!";
            StartCoroutine(EndGame(IMiniGame.MiniGameResult.WIN));
        }

        if (enableShot && canShoot)
        {
            source.PlayOneShot(playerShoot, .5f);
            enableShot = false;
            StartCoroutine(Cd());
        }
        if (!enableShot) {
            canShoot = false;
        }

        canShoot = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1);


        //Pointer Movement
        moveVer = InputManager.Instance.GetAxisVertical();
        moveHor = InputManager.Instance.GetAxisHorizontal();

        transform.Translate(0, moveVer * vely * Time.deltaTime, 0);
        transform.Translate(moveHor * vely * Time.deltaTime, 0, 0);

        if (transform.position.y > maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x > maxposx)
        {
            tmpPosition = new Vector3(maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.y < -maxposy)
        {
            tmpPosition = new Vector3(transform.position.x, -maxposy, transform.position.z);
            transform.position = tmpPosition;
        }

        if (transform.position.x < -maxposx)
        {
            tmpPosition = new Vector3(-maxposx, transform.position.y, transform.position.z);
            transform.position = tmpPosition;
        }
    }

    IEnumerator EndGame(IMiniGame.MiniGameResult result)
    {
        yield return new WaitForSecondsRealtime(3f);
        Gm.EndGame(result);
    }

    IEnumerator Cd()
    {
        yield return new WaitForSecondsRealtime(.5f);
        enableShot = true;
    }


}