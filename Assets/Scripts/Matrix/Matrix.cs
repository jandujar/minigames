using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix : IMiniGame
{
    public float timer;
    public SPlayer Player;
    public BulletSpawner bspawner;
    public Text countdown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void beginGame()
    {
        StartCoroutine(bspawner.SpawnBullet());
        StartCoroutine(Win());
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        Player.gm = gm;
    }

    public override string ToString()
    {
        return "Matrix by Luka";
    }

    private IEnumerator Win() {
        for (int i = (int)timer; i >= 0; i--)
        {
            countdown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Player.gm.EndGame(MiniGameResult.WIN);
    }
}