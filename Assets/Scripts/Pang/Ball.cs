using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Ball : MonoBehaviour
    {
        public Vector2 initSpeed;
        public Vector2 currentSpeed;
        // Start is called before the first frame update
        void Start()
        {
            currentSpeed = initSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P)){
                Split();
            }
            transform.position = new Vector2(transform.position.x + currentSpeed.x * Time.deltaTime, transform.position.y + currentSpeed.y * Time.deltaTime);
        }
        void OnCollisionEnter2D(Collision2D col){
            Debug.Log(col.contacts[0].normal);
            if(col.contacts[0].normal.x != 0){
                currentSpeed = new Vector2(currentSpeed.x * -1, currentSpeed.y);
            }
            else if(col.contacts[0].normal.y != 0){
                currentSpeed = new Vector2(currentSpeed.x , currentSpeed.y * -1);
            }
            //currentSpeed = new Vector2(currentSpeed.x + (col.contacts[0].normal.x * (currentSpeed.x * 2)), currentSpeed.y + (col.contacts[0].normal.y * (currentSpeed.y * 2)));
        }
        void OnTriggerEnter2D(Collider2D other){
            if(other.name.ToLower().Contains("shot") || other.name.ToLower().Contains("chain")){
                Split();
            }
        }
        public void Split(){
            if(transform.localScale.x > 0.015){
                GameObject temp1 = Instantiate(gameObject, transform.position, transform.rotation);
                temp1.GetComponent<Ball>().initSpeed = new Vector2(-2,2);
                temp1.transform.position = transform.position + Vector3.left; 
                temp1.transform.localScale = transform.localScale/2; 
                GameObject temp2 = Instantiate(gameObject, transform.position, transform.rotation);
                temp2.GetComponent<Ball>().initSpeed = new Vector2(2,2);
                temp2.transform.position = transform.position + Vector3.right; 
                temp2.transform.localScale = transform.localScale/2;
            }
            Destroy(gameObject);
        }
    }
}
