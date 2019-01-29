using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eric_Sanchez_Verges
{
    public class cupController : MonoBehaviour
   {
    
    Vector3 initPosition;
    Transform tf;
    bool beginMove;
    float velocity;
    public float speed;
    public Vector3[] positions;
    Vector3[] movRight = new Vector3[5];
    Vector3[] movLeft = new Vector3[5];
    public bool hasBall, endPath;
    public int currentPosition;
    int target;
    public bool movingRight, movingLeft;
    // Start is called before the first frame update
    void Start()
    {
        
        setPoints();
        target = 0;
        tf = GetComponent<Transform>();
        initPosition = tf.position;
        endPath = true;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = speed * Time.deltaTime;


    }

    public bool moveRight()
    {

        if (!beginMove)
        {
            positions[target] = new Vector3(movRight[target].x,0, movRight[target].z) + new Vector3(initPosition.x,0, initPosition.z);
            beginMove = true;
            endPath = false;
        }
        

        tf.position = Vector3.MoveTowards(tf.position, positions[target], velocity);
        if (tf.position == positions[target] && positions.Length > target + 1)
        {
            target++;
            beginMove = false;
        }
        if (tf.position == positions[target] && target == 4)
        {
            initPosition = tf.position;
            currentPosition += 1;
                
            target = 0;
            beginMove = false;
            return endPath = true;

            }
            return false;
        Debug.Log("Moving to target = " + target);
    }

    public bool moveLeft()
    {

        if (!beginMove)
        {
            positions[target] = new Vector3(movLeft[target].x, 0, movLeft[target].z) + new Vector3(initPosition.x, 0, initPosition.z);
            beginMove = true;
            endPath = false;
        }
        

        tf.position = Vector3.MoveTowards(tf.position, positions[target], velocity);
        if (tf.position == positions[target] && positions.Length > target + 1)
        {
            target++;
            beginMove = false;


        }
        if (tf.position == positions[target] && target == 4)
        {
            initPosition = tf.position;
            currentPosition += 1;
                
            target = 0;
            beginMove = false;
            return endPath = true;

            }
            return false;

            Debug.Log("Moving to target = " + target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        for (int i = 0; i < positions.Length; i++)
        Gizmos.DrawCube(positions[i], new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.DrawCube(initPosition, new Vector3(1, 1, 1));
    }

    void setPoints()
    {
        movRight[0] = new Vector3(0.07f, 0, 0.77f);
        movRight[1] = new Vector3(0.88f, 0, 1.43f);
        movRight[2] = new Vector3(1.91f, 0, 1.48f);
        movRight[3] = new Vector3(2.64f, 0, 0.77f);
        movRight[4] = new Vector3(2.70f, 0, 0);

        movLeft[0] = new Vector3(-0.07f, 0, -0.77f);
        movLeft[1] = new Vector3(-0.88f, 0, -1.43f);
        movLeft[2] = new Vector3(-1.91f, 0, -1.48f);
        movLeft[3] = new Vector3(-2.64f, 0, -0.77f);
        movLeft[4] = new Vector3(-2.70f, 0, 0);
    }
}
}

