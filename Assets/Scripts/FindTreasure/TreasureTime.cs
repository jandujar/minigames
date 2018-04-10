using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureTime : MonoBehaviour
{

    [SerializeField]
    private Text timeUI;

    [SerializeField]
    private int maxTime = 10;

    [SerializeField]
    private TreasureFinder treasureFinder;

    public void StartTime()
    {
        StartCoroutine("timeToEnd");
    }

    public IEnumerator timeToEnd()
    {
        while (maxTime > 0)
        {
            timeUI.text = maxTime.ToString();
            yield return new WaitForSeconds(1);
            maxTime--;
        }
        treasureFinder.lose();
        stopTime();
    }

    public void stopTime()
    {
        StopCoroutine("timeToEnd");
    }
}