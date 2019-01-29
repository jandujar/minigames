using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    /*********************************************************************************************************************************
     *              Variables                                                                                                        *
     * *******************************************************************************************************************************/
    //movement mechanics
    //BOOLS

    public GameObject Game;


    public bool canMove;
    public bool stopInThePoints;
    public bool stopTimeIsRandom;
    [Range(0, 10)] public float maxTimeWaiting;
    public bool loopRoute;

    private int currentPoint, lastPoint;
    public Vector3[] Points;
    private float TimeWaiting;
    private int goingBackNum;

    [SerializeField] float speedNPC;

    public bool debugBoolForMatchingNPCPos = false; //DEBUG TOOL TO BE DELETEEEEED
    public bool moveGizmoswithObject = false; //moves also de positions when the object is moving, keeping its position
    private Vector3[] relativePosition;
    private Vector3 ObjectOriginPosition;

    //COLLISIONS
    bool hits;
    RaycastHit hitobject;

    // Use this for initialization
    public void Start()
    {
        //movement
        if (canMove)
            InitMoveVars();


        /*
        if (moveGizmoswithObject)
        {
            ObjectOriginPosition = transform.position;
            Points[0] = ObjectOriginPosition;
            relativePosition = new Vector3[Points.Length];
            for (int i = 1; i < Points.Length; i++)
            {
                relativePosition[i] = Points[0] - Points[i];
                relativePosition[i].z = 0;
            }
        }
        */
    }
    //We will used it, but now, the NPCs don't used it so, we don't want to waste processing time
    private void Update()
    {

        if (canMove)
        {

            if (Vector3.Distance(gameObject.transform.position, Points[currentPoint]) < 0.1f)
            {

                if (stopInThePoints)                                            //if we decided to stop in everypoint
                {
                    TimeWaiting -= Time.deltaTime;
                    if (maxTimeWaiting-TimeWaiting < 0.5f)
                    {
                        if (Physics.Linecast(Points[currentPoint], Points[lastPoint], out hitobject))
                        {
                            if (hitobject.collider.gameObject.tag == "Player")
                            
                            PlayerHitted();
                        }
                    }
                    if (TimeWaiting <= 0)                                        //when time finished
                    {
                        if (stopTimeIsRandom)                                   //if we decided to do random stop intervals
                            TimeWaiting = Random.Range(0, maxTimeWaiting);
                        else                                                    //if not
                            TimeWaiting = maxTimeWaiting;
                        
                        lastPoint = currentPoint;
                        currentPoint += 1 * goingBackNum;
                        
                    }
                }
                else
                {
                    lastPoint = currentPoint;
                    currentPoint += 1 * goingBackNum;
                }


                if (loopRoute)                                                  //if we decided to loop back to the start
                {
                    if (currentPoint >= Points.Length)
                    {
                        
                        currentPoint = 0;
                    }
                }
                else                                                            //if it doesnot loop, it will retrack the pathto the start
                {
                    if (currentPoint >= Points.Length)
                    {
                        goingBackNum *= -1;
                        currentPoint = Points.Length - 2;
                    }
                    else if (currentPoint < 0)
                    {

                        goingBackNum *= -1;
                        currentPoint = 1;

                    }
                }

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Points[currentPoint] , speedNPC * Time.deltaTime);
            }

            if (!stopInThePoints)
            {
                //PHYSICS for the trail if he is not stopping
                for (int i = 0; i < Points.Length - 1; i++)
                {
                    Debug.DrawLine(Points[i], Points[i + 1]);
                    if (Physics.Linecast(Points[i], Points[i + 1], out hitobject)){
                        if (hitobject.collider.gameObject.tag == "Player")
                            PlayerHitted();
                    }

                }
                Debug.DrawLine(Points[0], Points[Points.Length - 1]);
                if (loopRoute & Physics.Linecast(Points[0], Points[Points.Length - 1], out hitobject))
                {
                    
                    if (hitobject.collider.gameObject.tag == "Player")
                        PlayerHitted();
                }
                
            }

        }

    }

    void PlayerHitted()
    {

        Game.GetComponent<ImpGameEng>().hittedOnetime = true;
        
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerHitted();
    }


    /*********************************************************************************************************************************
     *              Functions of NPCs                                                                                                *
     * *******************************************************************************************************************************/

    //start of the movement vars and functions
    protected void InitMoveVars()
    {
        //if there's no moving points it will not be called
        if (Points.Length <= 0)
        {
            canMove = false;
            return;
        }

        if (stopTimeIsRandom)
            TimeWaiting = Random.Range(0, maxTimeWaiting);
        else
            TimeWaiting = maxTimeWaiting;

        goingBackNum = 1;

        //bools
        //if (loopRoute)
        //    patrolRoute = false;

        //we initialize the Init Position, where it will start.
        Points[0] = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    private void OnDrawGizmos()
    {

        if (canMove)
        {
            if (debugBoolForMatchingNPCPos)
                Points[0] = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            //Starting Point
            Gizmos.color = Color.green;
            Gizmos.DrawCube(Points[0], new Vector3(0.5f, 0.5f, 0.5f));
            if (0 != Points.Length - 1)
                Debug.DrawLine(Points[0], Points[0 + 1], Color.blue);
            

            //Inside Points
            Gizmos.color = Color.blue;
            for (int i = 1; i < Points.Length - 1; i++)
            {
                Gizmos.DrawCube(Points[i], new Vector3(0.5f, 0.5f, 0.5f));
                if (i != Points.Length - 1)
                    Debug.DrawLine(Points[i], Points[i + 1], Color.blue);
                
            }

            //EndPoint
            Gizmos.color = Color.red;
            Gizmos.DrawCube(Points[Points.Length - 1], new Vector3(0.5f, 0.5f, 0.5f));

            if (stopInThePoints)
                Debug.DrawLine(Points[currentPoint], Points[lastPoint], Color.yellow);

        }



    }

 

}
