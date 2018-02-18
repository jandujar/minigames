using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingCanKo : MonoBehaviour {

    public GameManager gameManager;
    public BoxingPlayerController boxingPlayer;
    private Animator anim;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
		if (boxingPlayer.aviableKo)
        {
            anim.SetBool("canKo", true);
        }
        else
        {
            anim.SetBool("canKo", false);
        }
	}
}
