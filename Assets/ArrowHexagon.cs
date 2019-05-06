using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHexagon : MonoBehaviour
{
    [SerializeField] GameObject HexagonManager;
    private GameManager gameManager;
    public float speed;
    float control;
    float lastControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        control = InputManager.Instance.GetAxisHorizontal();

        //Right
        if (control > 0.1 && control >= lastControl)
            this.gameObject.transform.parent.Rotate(Vector3.up, speed * Time.deltaTime);
        
        //Left
        if (control < -0.1 && control <= lastControl)
            this.gameObject.transform.parent.Rotate(Vector3.up, -speed * Time.deltaTime);
        
        lastControl = control;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            HexagonManager.GetComponent<TheHexagon>().Lose();
    }
 

}

//if (other.CompareTag("Player"))
//{
//    gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
//}