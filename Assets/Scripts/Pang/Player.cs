using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Player : MonoBehaviour
    {
        float speed;
        [SerializeField] GameObject shotPrefab;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            UpdateControls();
            if(Input.GetKeyDown(KeyCode.O) && !GameObject.Find("Shot(Clone)")){
                GameObject temp = Instantiate(shotPrefab, transform.position + Vector3.up, shotPrefab.transform.rotation);
            }
        }
        void FixedUpdate(){
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        void UpdateControls()
        {
            speed = InputManager.Instance.GetAxisHorizontal() / 5;
        }
    }
}
