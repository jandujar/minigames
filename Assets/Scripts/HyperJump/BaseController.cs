using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HyperJump
{
    public class BaseController : MonoBehaviour
    {
        Vector3 rotation;
        [SerializeField] float rotationSpeed;
        float axis;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)) axis = 1;
            else if (InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON2)) axis = -1;
            else axis = 0;
        }

        void FixedUpdate()
        {
            rotation = transform.rotation.eulerAngles;
            rotation += Vector3.up * axis * rotationSpeed;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
