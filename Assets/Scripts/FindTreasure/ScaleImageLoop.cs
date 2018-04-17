using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleImageLoop : MonoBehaviour
{

    private Vector3 baseScale;

    [SerializeField]
    private float scaleMultiplier = 2;
    [SerializeField]
    private float speed = 15;

    private bool goBack = false;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        baseScale = rectTransform.localScale;
    }

    private void Update()
    {
        if (!goBack)
        {
            if (rectTransform.localScale == (baseScale * scaleMultiplier))
            {
                goBack = true;
            }
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, baseScale * scaleMultiplier, speed * Time.deltaTime);
        }
        else
        {
            if (rectTransform.localScale == baseScale)
            {
                goBack = false;
            }
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, baseScale, speed * Time.deltaTime);
        }
    }
}