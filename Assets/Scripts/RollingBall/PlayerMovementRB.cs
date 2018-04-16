using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRB : MonoBehaviour {

    private GameManager gameManager;

    public GameObject winS;
    public GameObject loseS;

	public Vector3[] positions;

	private int currentPos;
    private bool win;
    private bool imAlive;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

	// Use this for initialization
	void Start () {
        imAlive = true;
		currentPos = 1; 
		win = true;
		StartCoroutine(WinCele());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * 250);
        if (imAlive)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                transform.GetComponent<AudioSource>().Play();
                currentPos--;
                if (currentPos <= 0)
                {
                    currentPos = 0;
                }
                transform.position = positions[currentPos];
            }
            if (Input.GetButtonDown("Fire1"))
            {
                transform.GetComponent<AudioSource>().Play();
                currentPos++;
                if (currentPos >= 2)
                {
                    currentPos = 2;
                }
                transform.position = positions[currentPos];
            }
        }		
	}

	IEnumerator WinCele(){
		yield return new WaitForSeconds(22);
		if(win){
            winS.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3.5f);
            gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Cube"){
			gameObject.transform.position = new Vector3(300,300,300);
			win = false;
            imAlive = false;
            StartCoroutine(LooseTime());
        }
	}

    IEnumerator LooseTime()
    {
        loseS.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
    }

}
