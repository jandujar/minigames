using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour {

    private Knife knife;
    [Tooltip("Percent")][SerializeField]private float marginError = 10;
    [SerializeField]private GameObject atkObjective;
    [SerializeField]private GameObject hand;
    private GameObject[] fingers;

    public string inputName = "Knife";

    [SerializeField]private float speed = 5;
    private Vector3 startPos;
    [SerializeField]private GameObject blood;
    private GameManager gameManager;
    [SerializeField]private float endTimer = 0.5f;
    private AudioSource sound;

    public void init(GameManager gm)
    {
        gameManager = gm;
    }

    private enum state { moving, attack, back, damage };
    private state attack;

	void Awake () {
        startPos = gameObject.transform.position;
        knife = gameObject.GetComponent<Knife>();
        fingers = new GameObject[hand.transform.childCount];
        for (int i = 0; i < fingers.Length; i++)
        {
            fingers[i] = hand.transform.GetChild(i).gameObject;
        }
        attack = state.moving;
        marginError = marginErrorPercent(atkObjective.transform.position.z);
        sound = gameObject.GetComponent<AudioSource>();
    }

    float marginErrorPercent(float value)
    {
        return (value * marginError / 100);
    }

    void Update()
    { 
        if (attack == state.attack)
        {
            
        }
        switch (attack)
        {
            case state.moving:
                if ((InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) ||
                    InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ||
                    InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3) ||
                    InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) && knife.enableKnife)
                {
                    knife.enableKnife = false;
                    attack = state.attack;
                }
                break;
            case state.attack:
                if (gameObject.transform.position.z >= atkObjective.transform.position.z - marginError)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, atkObjective.transform.position.z);
                    attack = state.back;
                }
                else
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Mathf.Lerp(gameObject.transform.position.z,
                        atkObjective.transform.position.z, speed * Time.deltaTime));
                }
                break;
            case state.back:
                if (gameObject.transform.position.z <= startPos.z + marginError)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, startPos.z);
                    knife.enableKnife = true;
                    attack = state.moving;
                }
                else
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Mathf.Lerp(gameObject.transform.position.z,
                        startPos.z, speed * Time.deltaTime));
                }
                break;
            case state.damage:
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == hand || isAFinger(col))
        {
            sound.Play();
            stopKnife();
            blood.transform.position = gameObject.transform.position;
            blood.SetActive(true);
            StartCoroutine("EndMinigame", endTimer);
        }
    }

    private IEnumerator EndMinigame(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        yield return null;
    }

    public void stopKnife()
    {
        attack = state.damage;
        knife.enableKnife = false;
    }

    public void setVictory()
    {
        gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
    }

    bool isAFinger(Collider col)
    {
        for (int i = 0; i < fingers.Length; i++)
        {
            if (fingers[i] == col.gameObject)
            {
                return true;
                //break;
            }
        }
        return false;
    }
}