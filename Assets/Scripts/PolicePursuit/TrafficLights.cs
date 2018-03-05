using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;

    private ThiefCar[] script;

    private float[] baseSpeed;

    [SerializeField]private bool isRed = false;

    private bool cooldown = false;

    [SerializeField]
    private float wait = 0.75f;

    [SerializeField]
    private Sprite[] colorSprite;

    private SpriteRenderer render;
    private AudioSource audio;

    void Start()
    {
        script = new ThiefCar[characters.Length];
        baseSpeed = new float[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            script[i] = characters[i].GetComponent<ThiefCar>();
            baseSpeed[i] = script[i].moveSpeed;
        }
        render = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1) ||
             InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2) ||
             InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON3) ||
             InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON4)) && !cooldown)
        {
            isRed = (isRed == true) ? false : true;
            if (isRed)
            {
                render.sprite = colorSprite[0];
            }
            else
            {
                render.sprite = colorSprite[1];
            }
            audio.Play();
            cooldown = true;
            StartCoroutine("ResetCooldown", wait);
        }
    }

    IEnumerator ResetCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        cooldown = false;
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isRed)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (col.gameObject == characters[i])
                {
                    if (script[i].moveSpeed == baseSpeed[i])
                    {
                        script[i].moveSpeed = 0;
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!isRed)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (col.gameObject == characters[i])
                {
                    if (script[i].moveSpeed == 0)
                    {
                        script[i].moveSpeed = baseSpeed[i];
                    }
                }
            }
        }
    }

    public bool getIsRed()
    {
        return isRed;
    }

    public void setIsRed(bool newIsRed)
    {
        isRed = newIsRed;
        if (isRed)
        {
            render.sprite = colorSprite[0];
        }
        else
        {
            render.sprite = colorSprite[1];
        }
    }
}