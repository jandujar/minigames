using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour
{

    [SerializeField]
    public AudioSource winsound;
    private BGmusic bg;
    public GameManager gm;

	// Use this for initialization
	void Start()
    {
        winsound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "win")
        {
            bg.music.Stop();
            //winsound.Play();

            Debug.Log("colisionaste con la winner flag");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "death")
        {
            StartCoroutine(EndLose());
            Debug.Log("te moriste joputa");
        }
    }
    public IEnumerator EndLose()
    {
        yield return new WaitForSeconds(0.3f);
        gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }


}

