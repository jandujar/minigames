using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingPlayerController : MonoBehaviour {

    public GameManager gameManager;
    public BoxingEnemyController boxingEnemy;
    private AudioSource boxingAudience;
    private float move;
    private float posX;
    private float posY;
    private bool charguePunch;
    public int chargueKo = 0;
    public bool aviableKo;
    public bool releaseKo;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    // Use this for initialization
    void Start () {       
        posX = transform.position.x;
        posY = transform.position.y;
        boxingAudience = GetComponent<AudioSource>();
        StartCoroutine(DisablePunch());
        StartCoroutine(StartSound());
    }

    IEnumerator DisablePunch()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(4);
        boxingAudience.Play();
    }

    IEnumerator WinMatch()
    {
        boxingEnemy.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Instantiate(GameObject.Find("Win"), new Vector3(-0.2f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }
	
	// Update is called once per frame
	void Update () {

		move = InputManager.Instance.GetAxisHorizontal();

        

        if (move > 0)
        {
            transform.position = new Vector2(posX + 3,posY);
        }
        else if (move < 0)
        {
            transform.position = new Vector2(posX - 3, posY);
        }
        else
        {
            transform.position = new Vector2(posX, posY);
        }

        charguePunch = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1);

        if (charguePunch)
        {
            chargueKo = chargueKo + 30;
        }
        else
        {
            chargueKo--;
            if (chargueKo < 0)
            {
                chargueKo = 0;
            }
            
        }

        releaseKo = InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2);

        if (chargueKo > 500)
        {
            aviableKo = true;
        }
        else
        {
            aviableKo = false;
        }

        if (aviableKo && releaseKo)
        {
            chargueKo = 0;
            transform.GetChild(0).gameObject.SetActive(true);

            if (boxingEnemy.transform.position.x == transform.position.x)
            {
                StartCoroutine(WinMatch());  
            }
        }

        if (transform.GetChild(0).gameObject.activeSelf)
        {
            StartCoroutine(DisablePunch());
        }

	}
}
