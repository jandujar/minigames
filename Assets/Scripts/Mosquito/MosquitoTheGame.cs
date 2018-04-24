using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoTheGame : IMiniGame {

    public MosquitoMove mosquito;
	public EspatulaMove espatula;
    private AudioSource source;

    public override void beginGame()
    {
        //source = GetComponent<AudioSource>();
        //source.Play();
        Debug.Log(this.ToString() + " game Begin");
        mosquito.enabled = true;
		espatula.enabled = true;

    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        mosquito.init(gm);
		espatula.init(gm);

    }
    public override string ToString()
    {
        return "Mosquito The Game by Roger";
    }
}
