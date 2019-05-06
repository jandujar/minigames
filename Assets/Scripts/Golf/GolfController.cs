using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfController : MonoBehaviour
{

    [SerializeField] float MULTI_FORCE = 300;

    [SerializeField] GolfBall paperball;

    [SerializeField] float minValueDirection, maxValueDirection;
    [SerializeField] float minValueForce, maxValueForce;
    [SerializeField] float minArrowScale, maxArrowScale;
    [SerializeField] float verticalAngle;

    int currentRound, currentAttempts;
    [SerializeField] int roundsToWinGame, maxAttempts;

    Vector3 paperballInitPosition;

    public Vector3 directionShot;
    public float forceShot;

    public float tempValue, tempInc;

    [SerializeField] Transform arrow;

    float AEqValue, BEqValue, CEqValue;

    [SerializeField] GolfManager manager;
    [SerializeField] GameObject gameCamera;
    Vector3 cameraRotation, cameraDistance;
    [SerializeField] GameObject[] movablePlatforms;

    // Use this for initialization
    void Start()
    {
        //Ecuacion para encontrar el valor de la escala cuando hagamos la flecha grande y pequeña
        //Vector director = (-B, A) --> B = -x & A = y
        AEqValue = maxValueForce - minValueForce; // A = Vy
        BEqValue = -(maxArrowScale - minArrowScale); // B = -Vx
        CEqValue = -(AEqValue * minArrowScale + BEqValue * minValueForce); // Ax + By + C = 0

        currentRound = 0;
        paperballInitPosition = paperball.transform.position;
        ResetPosition();
        cameraRotation = gameCamera.transform.rotation.eulerAngles;
        cameraDistance = paperballInitPosition - gameCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        gameCamera.transform.position = 
            Vector3.Lerp(gameCamera.transform.position, paperball.transform.position - cameraDistance, 1f);
    }

    void UpdateInput()
    {
        if (directionShot.Equals(Vector3.zero))
        {
            UpdateDirectionInput();
        }
        else if (forceShot == 0)
        {
            UpdateForceInput();
        }
        else
        {
            return;
        }
    }

    void UpdateDirectionInput()
    {
        tempValue += InputManager.Instance.GetAxisHorizontal();

        arrow.rotation = Quaternion.Euler(90, tempValue, -90);

        if (tempValue >= maxValueDirection)
        {
            tempInc *= -1;
            tempValue = maxValueDirection;
        }
        else if (tempValue <= minValueDirection)
        {
            tempInc *= -1;
            tempValue = minValueDirection;
        }

        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            directionShot = new Vector3(Mathf.Sin(Mathf.Deg2Rad * tempValue), Mathf.Sin(Mathf.Deg2Rad * verticalAngle), Mathf.Cos(Mathf.Deg2Rad * tempValue));
            tempValue = 0;
            tempInc = Mathf.Abs(tempInc);
        }
    }

    void UpdateForceInput()
    {
        tempValue += Time.deltaTime * tempInc;
        //Ecuacion para encontrar el valor de escala correspondiente: Ax + By + C = 0 --> 
        //x = (-By - C) / A
        arrow.localScale = new Vector3((-BEqValue * tempValue - CEqValue) / AEqValue, arrow.localScale.y, arrow.localScale.z);

        if (tempValue >= maxValueForce)
        {
            tempInc *= -1;
            tempValue = maxValueForce;
        }
        else if (tempValue <= minValueForce)
        {
            tempInc *= -1;
            tempValue = minValueForce;
        }

        if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        {
            arrow.gameObject.SetActive(false);
            forceShot = tempValue * MULTI_FORCE;
            paperball.AddForce(forceShot, directionShot);
            tempInc = Mathf.Abs(tempInc);
            tempValue = 0;
        }
    }

    public void NextRound()
    {
        Debug.Log("Winner winner chicken dinner");
        currentRound++;
        manager.EndGame(true);
        //ResetPosition();
    }

    public void ResetPosition()
    {
        if (++currentAttempts > maxAttempts) manager.EndGame(false);

        arrow.gameObject.SetActive(true);
        forceShot = 0;
        directionShot = Vector3.zero;
        paperball.gameObject.GetComponent<Rigidbody>().useGravity = false;
        arrow.localScale = new Vector3((-BEqValue * minValueForce - CEqValue) / AEqValue, arrow.localScale.y, arrow.localScale.z);
    }
}
