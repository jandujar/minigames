using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public GameManager gameManager = null;
    public Snake_Luka game = null;

    [SerializeField]
    GameObject[] body;

    Vector3[] bodyPositions;

    [SerializeField]
    float speed = 0f;

    Vector3 initPos,
        finalPos;

    float movementDistance = 1f;

    [SerializeField]
    AudioClip   pickUpCoin,
                snakeCrash;

    AudioSource audioSource;

    enum Orders
    {
        VERTICAL = 0x0001,
        HORIZONTAL = 0x0010,
        POSITIVE = 0x0100,
        NEGATIVE = 0x1000,
        UP = 0x0101,
        DOWN = 0x1001,
        LEFT = 0x1010,
        RIGHT = 0x0110
    }

    Orders lastOrder = Orders.UP;
    Orders prevOrder = Orders.UP;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        bodyPositions = new Vector3[body.Length];

        for (int i = 0; i < body.Length; i++)
        {
            bodyPositions[i] = body[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal");
        float Yaxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            AddBodyPart();

        if (Xaxis > 0f)
            lastOrder = Orders.RIGHT;
        else if (Xaxis < 0f)
            lastOrder = Orders.LEFT;

        if (Yaxis > 0f)
            lastOrder = Orders.UP;
        else if (Yaxis < 0f)
            lastOrder = Orders.DOWN;
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "schutzstaffel_b") //monedita
        {
            Destroy(other.gameObject);
            game.Score++;
            speed *= 1.1f;

            AddBodyPart();

            audioSource.clip = pickUpCoin;
            audioSource.Play();

            game.SpawnCoin();

            if (game.Score >= game.TargetScore)
            {
                gameManager.EndGame(IMiniGame.MiniGameResult.WIN);
            }
        }
        else if (other.tag == "schutzstaffel_a" || other.tag == "wehrmacht_b")
        {
            audioSource.clip = snakeCrash;
            audioSource.Play();
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);
        }
        else if (other.CompareTag("GameController") || other.CompareTag("Finish") || other.CompareTag("Respawn"))
        {
            audioSource.clip = snakeCrash;
            audioSource.Play();
            gameManager.EndGame(IMiniGame.MiniGameResult.LOSE);

        }
    }

    void AddBodyPart()
    {
        GameObject[] newBody = new GameObject[body.Length + 1];
        body.CopyTo(newBody, 0);
        newBody[body.Length] = Instantiate(body[0], body[body.Length - 1].transform.position, body[body.Length - 1].transform.rotation);
        body = newBody;

        Vector3[] newPositions = new Vector3[bodyPositions.Length + 1];
        bodyPositions.CopyTo(newPositions, 0);
        newPositions[bodyPositions.Length] = newPositions[bodyPositions.Length - 1];
        bodyPositions = newPositions;
    }

    public void StartMoving()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        initPos = transform.position;
        Vector3 directionVector = Vector3.zero;
        float angle = 0f;

        if ((prevOrder & Orders.VERTICAL) != 0 && (lastOrder & Orders.VERTICAL) != 0)
            lastOrder = prevOrder;

        if ((prevOrder & Orders.HORIZONTAL) != 0 && (lastOrder & Orders.HORIZONTAL) != 0)
            lastOrder = prevOrder;

        prevOrder = lastOrder;

        switch (lastOrder)
        {
            case Orders.UP:
                angle = 0f;
                directionVector = Vector3.up * movementDistance;
                break;
            case Orders.DOWN:
                angle = 180f;
                directionVector = Vector3.down * movementDistance;
                break;
            case Orders.LEFT:
                angle = 270f;
                directionVector = Vector3.left * movementDistance;
                break;
            case Orders.RIGHT:
                angle = 90f;
                directionVector = Vector3.right * movementDistance;
                break;
        }
        finalPos = initPos + directionVector;

        Vector3 newRot = new Vector3(0f, 0f, angle);
        transform.eulerAngles = newRot;

        float interpolationPercent = 0f;
        while ((finalPos - transform.position).magnitude >= Vector3.kEpsilon)
        {
            Debug.DrawLine(initPos, finalPos, Color.blue, 5f);
            interpolationPercent += Time.fixedDeltaTime * speed;

            transform.position = Vector3.Lerp(initPos, finalPos, interpolationPercent);
            body[0].transform.position = Vector3.Lerp(bodyPositions[0], initPos, interpolationPercent);

            for (int i = 1; i < body.Length; i++)
            {
                body[i].transform.position = Vector3.Lerp(bodyPositions[i], bodyPositions[i - 1], interpolationPercent);
            }

            yield return new WaitForFixedUpdate();
        }

        //Clavar la posicio de les peces
        for (int i = body.Length - 1; i > 0; i--)
        {
            body[i].transform.position = bodyPositions[i] = bodyPositions[i - 1];
            body[i].transform.rotation = body[i - 1].transform.rotation;
        }

        transform.position = finalPos;
        body[0].transform.rotation = transform.rotation;
        body[0].transform.position = bodyPositions[0] = initPos;
        
        StartMoving();
    }
}