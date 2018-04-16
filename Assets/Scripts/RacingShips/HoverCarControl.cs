using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class HoverCarControl : MonoBehaviour
{
    Rigidbody m_body;
    float m_deadZone = 0.1f;

    public bool go = false;

    public float m_hoverForce = 9.0f;
    public float m_hoverHeight = 2.0f;
    public GameObject[] m_hoverPoints;

    public float m_forwardAcl = 100.0f;
    private float b_forwardAcl = 0;
    public float m_backwardAcl = 25.0f;
    private float m_turbo = 0.0f;

    [HideInInspector]
    public float m_currThrust = 0.0f;
    float m_currAntiThrust = 0.0f;

    public float m_turnStrength = 10f;
    float m_currTurn = 0.0f;

    public GameObject m_leftAirBrake;
    public GameObject m_rightAirBrake;

    public ParticleSystem p_flame;
    public GameObject Lights;

    int m_layerMask;

    private bool checkedRotation = false;

    public int raceTriggerNumber = 0;

    public string hoverName = "";

    [SerializeField]
    private Image TurboIMG;

    [HideInInspector]
    public float totalTurbo = 1;

    [SerializeField]
    private GameObject myCamera;
    [SerializeField]
    private GameObject mySecondCamera;
    //private float myCameraZ = 0;


    void Start()
    {
        m_body = GetComponent<Rigidbody>();

        m_layerMask = 1 << LayerMask.NameToLayer("Characters");
        m_layerMask = ~m_layerMask;

        b_forwardAcl = m_forwardAcl;

        TurboIMG.fillAmount = totalTurbo;
        //myCameraZ = 11.5f;
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


        // Main Thrust
        m_currThrust = 0.0f;
        m_currAntiThrust = 0.0f;
        bool aclAxis = InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1);
        if (aclAxis)
            m_currThrust = m_forwardAcl;

        bool dclAxis = InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON2);
        if (dclAxis)
            m_currAntiThrust = m_backwardAcl;

        // Turning
        m_currTurn = 0.0f;
        float turnAxis = InputManager.Instance.GetAxisHorizontal();
        if (Mathf.Abs(turnAxis) > m_deadZone)
            m_currTurn = turnAxis;

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON3) && totalTurbo > 0)
        {
            m_turbo = 5000.0f;
            totalTurbo -= .01f;
            if (totalTurbo < 0)
                totalTurbo = 0;

        }
        else
        {
            m_turbo = 0.0f;
        }

        if (InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4))
        {
            
            if (myCamera.activeSelf)
            {
                myCamera.SetActive(false);
                mySecondCamera.SetActive(true);
            }
            
        }
        else
        {
            if (mySecondCamera.activeSelf)
            {
                myCamera.SetActive(true);
                mySecondCamera.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {

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

        // Forward
        if (Mathf.Abs(m_currThrust) >= 0)
        {
            m_body.AddForce(transform.forward * (m_currThrust + m_turbo) * Time.deltaTime * 50);
        }
        if (Mathf.Abs(m_currAntiThrust) >= 0)
        {
            m_body.AddForce(transform.forward * m_currAntiThrust * -1 * Time.deltaTime * 50);
        }

        if (m_currThrust == 0 && m_currAntiThrust == 0)
        {
            if (Lights.activeSelf)
                Lights.SetActive(false);
        }
        else
        {
            if (!Lights.activeSelf)
                Lights.SetActive(true);
            if (m_currThrust > 0)
            {
                Lights.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
                Lights.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            if (m_currAntiThrust > 0 && m_currThrust == 0)
            {
                Lights.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
                Lights.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

        if (Mathf.Abs(m_currThrust) > 0 || Mathf.Abs(m_currAntiThrust) > 0)
        {
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
        else if (Mathf.Abs(m_currThrust) == 0 && Mathf.Abs(m_currAntiThrust) == 0)
        {
            if (GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Stop();
        }

        // Turn
        if (m_currTurn > 0)
        {
            m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength * Time.deltaTime * 50);
        }
        else if (m_currTurn < 0)
        {
            m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength * Time.deltaTime * 50);
        }
        transform.Rotate(new Vector3(0, 0, -m_currTurn));



    }
    IEnumerator WallDeceleration()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        m_forwardAcl = b_forwardAcl;
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
        /*
        yield return new WaitForSecondsRealtime(0.5f);
        m_forwardAcl = b_forwardAcl;
        */
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            m_forwardAcl -= 1000;
            if (m_forwardAcl <= 0)
                m_forwardAcl = 1000;
            StopCoroutine("WallDeceleration");
            StartCoroutine(WallDeceleration());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (int.Parse(other.name) == 1)
        {
            if (raceTriggerNumber == 0)
                raceTriggerNumber = 1;
            if (raceTriggerNumber == 5)
                raceTriggerNumber = 6;
        }

        if (raceTriggerNumber == int.Parse(other.name) - 1)
            raceTriggerNumber = int.Parse(other.name);

        //Debug.LogError(raceTriggerNumber);
    }
}
