using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Canvas gCan;

    public bool stop = false;

    public AudioClip[] fx;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gCan.enabled)
        {
            if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4) && !stop)
            {
                audioSource.clip = fx[0];
                audioSource.volume = 0.15f;
                audioSource.Play();
                stop = true;
            }
            if (stop)
            {
                RectTransform myRect = GetComponent<RectTransform>();

                myRect.transform.position = new Vector2(myRect.position.x, myRect.position.y - 5);
            }
        }
    }
}
