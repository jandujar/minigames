using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EspatulaMove : MonoBehaviour
{

    public AudioClip mosquitoSplat;
    private AudioSource source;
    public float speed = 1;
    public float pivotOffset = 5;
    public float maxVertical, maxHorizontal;
    public float maxPositionOffset;
    public bool attacking = false;
    Animator anim;

    GameManager gameManager;

    public int tries = 3;

    public Text txt;
	bool ended = false;
    public void init(GameManager gm)
    {

        gameManager = gm;
		txt.text = "you have  " + tries.ToString() + " tries to kill the mosquito";
		//source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        maxVertical = Camera.main.orthographicSize;
        maxVertical -= maxPositionOffset;

        maxHorizontal = maxVertical * Screen.width / Screen.height;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
		if (ended) {
			return;
		}
        if (!attacking)
        {
            Vector2 movement = new Vector2(InputManager.Instance.GetAxisHorizontal(), InputManager.Instance.GetAxisVertical());
            Vector3 newPosition = transform.position + (Vector3)movement * speed * Time.deltaTime;
            if (newPosition.x > maxHorizontal)
            {
                newPosition.x = maxHorizontal;
            }
            else if (newPosition.x < -maxHorizontal)
            {
                newPosition.x = -maxHorizontal;
            }

            if (newPosition.y > maxVertical + pivotOffset)
            {
                newPosition.y = pivotOffset + maxVertical;
            }
            else if (newPosition.y < pivotOffset - maxVertical)
            {
                newPosition.y = pivotOffset - maxVertical;
            }

            transform.position = newPosition;

            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
            {
                Attack();
            }
            
        }
    }

    void Attack()
    {
        attacking = true;
        anim.SetTrigger("attack");
    }
    public void StopAttack()
    {
        attacking = false;
        tries--;
		if (ended)
			return;
		if (tries <= 0 ) {
			


				ended = true;
				StartCoroutine (LoseGame ());


		} else {
			txt.text = "you have  " + tries.ToString() + " tries to kill the mosquito";
		}
    }

    void OnTriggerEnter2D(Collider2D other)
	{
         
		if (!ended) {
			if (other.gameObject.CompareTag ("Player")) {
				source.PlayOneShot (mosquitoSplat, .5f);
				MosquitoMove mosquito = other.gameObject.GetComponent<MosquitoMove> ();
				//if (mosquito != null) {
				//	mosquito.Kill ();
				//}
				ended = true;
				StartCoroutine (WinGame ());
			}
		}
	}
	IEnumerator WinGame()
	{
		txt.text = "YOU WIN";
		yield return new WaitForSeconds(3);

			gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
		
	}
	IEnumerator LoseGame()
	{
		txt.text = "YOU LOSE";
		
		yield return new WaitForSeconds(3);

		gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

	}

}
