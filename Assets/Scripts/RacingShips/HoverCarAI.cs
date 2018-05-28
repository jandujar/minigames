using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class HoverCarAI : MonoBehaviour
{
    Rigidbody m_body;


    public float m_hoverForce = 9.0f;
    public float m_hoverHeight = 2.0f;
    public GameObject[] m_hoverPoints;

    private float m_turbo = 0.0f;

    public float m_turnStrength = 10f;
    [HideInInspector]
    public float m_currTurn = 0.0f;

    public GameObject m_leftAirBrake;
    public GameObject m_rightAirBrake;

    public ParticleSystem p_flame;
    public GameObject Lights;

    int m_layerMask;


    public GameObject WayPoints;
    public float minDist;
    public float speed;
    private float b_Speed;


    public bool go = false;

    public WaypointTracker WpTracker;

    private int breakSpeed = 0;

    private bool checkedRotation = false;

    public GameObject hoverPlayer;

    public Transform Back;
    public Transform Front;

    public int raceTriggerNumber;

    public string hoverName = "";

    private float dist;


    [SerializeField]
    private Image TurboIMG;

    [HideInInspector]
    public float totalTurbo = 1;


    void Start()
    {
        m_body = GetComponent<Rigidbody>();

        m_layerMask = 1 << LayerMask.NameToLayer("Characters");
        m_layerMask = ~m_layerMask;

        b_Speed = speed;

        TurboIMG.fillAmount = totalTurbo;

    }

    void OnDrawGizmos()
    {

        //  Hover Force
        RaycastHit hit;
        for (int i = 0; i < m_hoverPoints.Length; i++)
        {
            var hoverPoint = m_hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position,
                                -Vector3.up, out hit,
                                m_hoverHeight,
                                m_layerMask))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(hoverPoint.transform.position, hit.point);
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(hoverPoint.transform.position,
                               hoverPoint.transform.position - Vector3.up * m_hoverHeight);
            }

        }
    }

    void Update()
    {
        if (!go)
            return;

        //update turbo
        TurboIMG.fillAmount = totalTurbo;
        checkParticles();

    }

    void FixedUpdate()
    {
        /*
        if (!go)
            return;
            */

        dist = Vector3.Distance(gameObject.transform.position, WpTracker.target.transform.position);

        if (dist > minDist && go)
        {
            Move();
        }

        if (!checkedRotation)
        {
            checkedRotation = true;
            StartCoroutine(CheckRotation());
        }

        //  Hover Force
        RaycastHit hit;
        for (int i = 0; i < m_hoverPoints.Length; i++)
        {
            var hoverPoint = m_hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position,
                                -Vector3.up, out hit,
                                m_hoverHeight,
                                m_layerMask))
            {
                m_body.AddForceAtPosition(Vector3.up
                  * m_hoverForce
                  * (1.0f - (hit.distance / m_hoverHeight)),
                                          hoverPoint.transform.position * Time.deltaTime * 50);

                if (hit.collider.gameObject.tag == "Respawn" && hoverPoint == m_hoverPoints[6])// && hoverPoint == m_hoverPoints[6]) solo el del medio
                {
                    m_turbo = 5000.0f;
                    totalTurbo = 1;
                }
            }

            else
            {
                if (transform.position.y > hoverPoint.transform.position.y)
                    m_body.AddForceAtPosition(
                      hoverPoint.transform.up * m_hoverForce,
                      hoverPoint.transform.position * Time.deltaTime * 50);
                else
                    m_body.AddForceAtPosition(
                      hoverPoint.transform.up * -m_hoverForce,
                      hoverPoint.transform.position * Time.deltaTime * 50);
            }
        }

    }


    public void Move()
    {
        checkTorque();


        if (Vector3.Distance(Front.position, hoverPlayer.transform.position) < Vector3.Distance(Back.position, hoverPlayer.transform.position))
        {
            //Player in front
            if (Vector3.Distance(Front.position, hoverPlayer.transform.position) > 0 && totalTurbo > 0)
            {
                m_turbo = 5000f;
                totalTurbo -= .01f;
            }
            else
                m_turbo = 0;

        }
        if (Vector3.Distance(Front.position, hoverPlayer.transform.position) > Vector3.Distance(Back.position, hoverPlayer.transform.position))
        {
            //Player in back
            if (Vector3.Distance(Back.position, hoverPlayer.transform.position) < 10 && totalTurbo > 0)
            {
                m_turbo = 5000f;
                totalTurbo -= .01f;
            }
            else
                m_turbo = 0;

        }
        if (totalTurbo < 0)
            totalTurbo = 0;


        m_body.AddForce(transform.forward * (speed - breakSpeed + m_turbo) * Time.deltaTime * 50);
    }


    private void checkTorque()
    {
        if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) < -0.1f)
        {
            // Debug.Log("Right");

            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) > -.4f)
                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * .25f * Time.deltaTime * 50);

            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) > -.8f && (Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) < -.4f)
            {
                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * .5f * Time.deltaTime * 50);
                breakSpeed = 2000;
            }
            else breakSpeed = 0;


            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) < -.8f)
            {
                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * 2 * Time.deltaTime * 50);
                breakSpeed = 3000;
            }
            else
            {
                breakSpeed = 0;
            }

        }

        else if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) > 0.1f)
        {
            //  Debug.Log("Left");
            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) < .4f)
                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * .25f * Time.deltaTime * 50);

            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) < .8f && (Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) > .4f)
            {
                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * .5f * Time.deltaTime * 50);
                breakSpeed = 2000;
            }
            else breakSpeed = 0;

            if ((Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) > .8f)
            {

                m_body.AddRelativeTorque(Vector3.up * -(Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position)) * m_turnStrength * 2 * Time.deltaTime * 50);
                breakSpeed = 3000;
            }
            else
            {
                breakSpeed = 0;
            }
        }

        transform.Rotate(new Vector3(0, 0, (Vector3.Distance(WpTracker.R.position, WpTracker.target.position) - Vector3.Distance(WpTracker.L.position, WpTracker.target.position))));
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed -= 1000;
            if (speed <= 0)
                speed = 1000;
            StopCoroutine("WallDeceleration");
            StartCoroutine(WallDeceleration());
        }
    }

    IEnumerator WallDeceleration()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        speed = b_Speed;
    }


    IEnumerator CheckRotation()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (transform.eulerAngles.z > 180)
        {
            if (transform.eulerAngles.z - 360 < -50)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        else
        {
            if (transform.eulerAngles.z > 50)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        checkedRotation = false;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Race Trigger")
        {
            if (int.Parse(other.name) == 1)
            {
                if (raceTriggerNumber == 0)
                    raceTriggerNumber = 1;
                if (raceTriggerNumber == 5)
                {
                    raceTriggerNumber = 6;
                    go = false;
                }
            }

            if (raceTriggerNumber == int.Parse(other.name) - 1)
                raceTriggerNumber = int.Parse(other.name);

            //Debug.LogError(raceTriggerNumber);
        }
    }

    private void checkParticles()
    {
        if (speed == 0)
        {
            if (Lights.activeSelf)
                Lights.SetActive(false);
        }
        else
        {
            if (!Lights.activeSelf)
                Lights.SetActive(true);
            if (speed > 0)
            {
                Lights.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
                Lights.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else
            {
                Lights.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
                Lights.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }



        if (m_turbo != 0)
        {
            if (!p_flame.isPlaying)
                p_flame.Play();
        }
        else
        {
            if (p_flame.isPlaying)
                p_flame.Stop();
        }

    }
}
