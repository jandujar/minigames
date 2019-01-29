using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Canvas gCan;

    public bool stop = false;

    int random = 0;

    // Start is called before the first frame update
    void Start()
    {
        random = UnityEngine.Random.Range(4, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (gCan.enabled)
        {
            if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4))
            {
                stop = true;
            }
            if (!stop)
            {
                RectTransform myRect = GetComponent<RectTransform>();

                myRect.transform.position = new Vector2(myRect.position.x + random, myRect.position.y);
            }
        }
    }
    
}
