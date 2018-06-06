using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public GameManager gameManager = null;
    public Snake_Luka game = null;

    [SerializeField]
    GameObject[] body;

    [SerializeField]
    float speed = 0f;

    Vector3 initPos,
        finalPos;

    float movementDistance = 1f;

    enum Orders
    {
        FORWARD,
        LEFT,
        RIGHT
    }

    Orders lastOrder = Orders.FORWARD;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "schutzstaffel_b") //monedita
        {
            Destroy(collision.gameObject);
            game.Score++;

            if (game.Score >= game.TargetScore)
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }
        else if (collision.collider.tag == "schutzstaffel_a" || collision.collider.tag == "wehrmacht_b")
        {
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
    }

    public void StartMoving()
    {
        StartCoroutine(Move(lastOrder));
    }

    IEnumerator Move(Orders direction)
    {
        initPos = transform.position;
        Vector3 directionVector = Vector3.zero;
        float angle = 0f;
        switch (direction)
        {
            case Orders.FORWARD:
                angle = 0f;
                directionVector = Vector3.up * movementDistance;
                break;
            case Orders.LEFT:
                angle = -90f;
                directionVector = Vector3.left * movementDistance;
                break;
            case Orders.RIGHT:
                angle = 90f;
                directionVector = Vector3.right * movementDistance;
                break;
        }
        finalPos = initPos + directionVector;

        transform.Rotate(Vector3.forward, angle);

        body[0].transform.LookAt(transform);

        for (int i = 1; i < body.Length; i++)
        {
            body[i].transform.LookAt(body[i-1].transform);
        }

        while ((finalPos - transform.position).magnitude >= Vector3.kEpsilon)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            for (int i = 0; i < body.Length; i++)
            {
                body[i].transform.Translate(Vector3.up * Time.deltaTime * speed);
            }

            yield return new WaitForEndOfFrame();
        }

        //Clavar la posicio de les peces

        StartCoroutine(Move(lastOrder));
    }
}