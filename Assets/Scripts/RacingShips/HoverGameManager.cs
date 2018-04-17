using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject HoverList;

    [SerializeField]
    private HoverCarControl HoverPlayer;

    [SerializeField]
    private List<HoverCarAI> HoverEnemies;

    private bool raceEnd = false;

    [SerializeField]
    private Text Countdown;

    private GameManager Gm;

    // Use this for initialization
    void Start()
    {
        Gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        HoverList = GameObject.Find("Hovers").gameObject;

        HoverPlayer = HoverList.transform.GetChild(0).gameObject.GetComponent<HoverCarControl>();

        for (int i = 1; i < HoverList.transform.childCount; i++)
        {
            HoverEnemies.Add(HoverList.transform.GetChild(i).gameObject.GetComponent<HoverCarAI>());
        }

        if (HoverPlayer != null)
            StartCoroutine(StartRace());

    }

    // Update is called once per frame
    void Update()
    {

        if (HoverPlayer.raceTriggerNumber == 6 && !raceEnd)
        {
            //Debug.Log("The Winner is: " + HoverPlayer.hoverName);
            raceEnd = true;
            HoverPlayer.go = false;
            HoverPlayer.m_currThrust = 0;
            HoverPlayer.totalTurbo = 0;
            Countdown.gameObject.SetActive(true);
            Countdown.text = "WIN";
            StartCoroutine(EndGame(true));


            for (int i = 0; i < HoverEnemies.Count; i++)
            {
                HoverEnemies[i].go = false;
                HoverEnemies[i].totalTurbo = 0;
            }
        }

        for (int i = 0; i < HoverEnemies.Count; i++)
        {
            if (HoverEnemies[i].raceTriggerNumber == 6 && !raceEnd)
            {
                //Debug.Log("The Winner is: " + HoverEnemies[i].hoverName);
                raceEnd = true;
                HoverEnemies[i].go = false;
                HoverPlayer.go = false;
                HoverPlayer.m_currThrust = 0;
                HoverPlayer.totalTurbo = 0;
                HoverEnemies[i].totalTurbo = 0;
                Countdown.gameObject.SetActive(true);
                Countdown.text = "LOOSE";
                StartCoroutine(EndGame(false));
            }
        }
    }

    IEnumerator StartRace()
    {
        yield return new WaitForSecondsRealtime(1);
        Countdown.text = "3";
        yield return new WaitForSecondsRealtime(1);
        Countdown.text = "2";
        yield return new WaitForSecondsRealtime(1);
        Countdown.text = "1";
        yield return new WaitForSecondsRealtime(1);
        Countdown.text = "GO!";
        HoverPlayer.go = true;
        for (int i = 0; i < HoverEnemies.Count; i++)
            HoverEnemies[i].go = true;
        yield return new WaitForSecondsRealtime(1);
        Countdown.gameObject.SetActive(false);
    }

    IEnumerator EndGame(bool _win)
    {
        yield return new WaitForSecondsRealtime(2f);
        if (_win)
            Gm.EndGame(IMiniGame.MiniGameResult.WIN);
        else
            Gm.EndGame(IMiniGame.MiniGameResult.LOSE);
    }
}
