using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public bool enableKnife;
    private GameManager gameManager;

    [SerializeField]private float speed;

    [SerializeField]private GameObject KnifePoints;

    public Vector2[] KnifePoint;
    public int CurrentPoint;
    public int LastPoint;

    private enum dir { right, left };
    private dir KnifeDir = dir.left;
    /*
    public void init(GameManager gm)
    {
        gameManager = gm;
    }*/

    void Awake()
    {
        KnifePoint = new Vector2[KnifePoints.transform.childCount];
        for (int i = 0; i < KnifePoint.Length; i++)
        {
            KnifePoint[i] = KnifePoints.transform.GetChild(i).gameObject.transform.position;
        }
        LastPoint = KnifePoints.transform.childCount - 1;
        CurrentPoint = 1;
        gameObject.transform.position = new Vector3(KnifePoint[0].x, KnifePoint[0].y, gameObject.transform.position.z);
    }

    void Update()
    {
        if (enableKnife)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                new Vector3(KnifePoint[CurrentPoint].x, KnifePoint[CurrentPoint].y, gameObject.transform.position.z),
                speed * Time.deltaTime);
            NextPoint();
            ChangeDir();
        }
    }

    void ChangeDir()
    {
        if (gameObject.transform.position.x >= KnifePoint[0].x && KnifeDir == dir.right &&
             gameObject.transform.position.y >= KnifePoint[0].y)
        {
            KnifeDir = dir.left;
            CurrentPoint++;
        }
        else if (gameObject.transform.position.x <= KnifePoint[LastPoint].x && KnifeDir == dir.left &&
                 gameObject.transform.position.y <= KnifePoint[LastPoint].y)
        {
            KnifeDir = dir.right;
            CurrentPoint--;
        }
    }

    void NextPoint()
    {
        if (KnifePoint[CurrentPoint] != KnifePoint[0] && KnifePoint[CurrentPoint] != KnifePoint[LastPoint])
        {
            if (gameObject.transform.position.x <= KnifePoint[CurrentPoint].x && KnifeDir == dir.left)
            {
                CurrentPoint++;
            }
            else if (gameObject.transform.position.x >= KnifePoint[CurrentPoint].x && KnifeDir == dir.right)
            {
                CurrentPoint--;
            }
        }
    }
}