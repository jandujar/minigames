using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanController : MonoBehaviour {
    public Transform target;
    public float speed;
    [SerializeField]
    private GameManager gameManager;

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    private void OnCollisionEnter(Collision collision)
    {Debug.Log("lost");
        if (collision.gameObject.name == "Final")
        {            
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }
}
