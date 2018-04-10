using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureFinder : MonoBehaviour
{

    [SerializeField]
    private Image finderUI;

    [SerializeField]
    private Text numberDistance;

    [SerializeField]
    private float[] ranges = new float[4];

    [SerializeField]
    private Color[] finderColors = new Color[4];

    [SerializeField]
    private GameObject treasure;

    [SerializeField]
    private RotateSphere rotateSphere;

    private GameManager gameManager;

    [SerializeField]
    private TreasureTime treasureTime;

    private bool isEnabled = false;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    public void enableFinder()
    {
        isEnabled = true;
        treasureTime.StartTime();
    }

    private void Update()
    {
        if (isEnabled)
        {
            if (Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude) > ranges[0])
            {
                finderUI.color = finderColors[0];
            }
            else if (Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude) > ranges[1])
            {
                finderUI.color = finderColors[1];
            }
            else if (Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude) > ranges[2])
            {
                finderUI.color = finderColors[2];
            }
            else if (Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude) < ranges[3])
            {
                finderUI.color = finderColors[3];
                if ((InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) ||
                        InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ||
                        InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3) ||
                        InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) && rotateSphere.enabled)
                {
                    treasureTime.stopTime();
                    gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
                    rotateSphere.enabled = false;
                }
            }
            else
            {
                finderUI.color = finderColors[2];
            }
            setDistance();
        }
    }

    private void setDistance()
    {
        if (Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude) < ranges[3])
        {
            numberDistance.text = 0 + " meters";
        }
        else
        {
            numberDistance.text = ((int)Mathf.Abs((treasure.transform.position - gameObject.transform.position).magnitude)).ToString() + " meters";
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Treasure>())
        {
            finderUI.color = finderColors[3];
        }
    }

    public void lose()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        rotateSphere.enabled = false;
    }
}