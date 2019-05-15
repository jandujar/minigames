using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfOscilator : MonoBehaviour
{
    [SerializeField] float frequency, maxOffset;
    [SerializeField] Vector3 direction;
    float currentOffset, currentTime, offset;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //Para evitar salirnos de rango y no afectar al movimiento
        if (currentTime > 2 * Mathf.PI) currentTime -= 2 * Mathf.PI; 

        //Ecuacion de MAS (Movimiento Armonico Simple)
        offset = maxOffset * Mathf.Sin(frequency * currentTime);

        transform.position = originalPos + offset * direction;
    }
}
