using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    [System.Serializable]
    public class Ball : MonoBehaviour
    {
        public Vector2 initSpeed;
        public Vector2 currentSpeed;
        float immuneTime = 0.5f;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<CircleCollider2D>().enabled = false;
            currentSpeed = initSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if(immuneTime > 0){
                immuneTime -= Time.deltaTime;
                if(immuneTime <= 0){
                    GetComponent<CircleCollider2D>().enabled = true;
                }
            }
            transform.position = new Vector2(transform.position.x + currentSpeed.x * Time.deltaTime, transform.position.y + currentSpeed.y * Time.deltaTime);
        }
        void OnCollisionEnter2D(Collision2D col){
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
            if(immuneTime > 0) return;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            if(transform.localScale.x > 1){
                GameObject temp1 = Instantiate(gameObject, transform.position, transform.rotation);
                temp1.GetComponent<Ball>().initSpeed = new Vector2(-(Mathf.Abs(currentSpeed.x)) * 1.1f,(Mathf.Abs(currentSpeed.y)) * 1.1f);
                temp1.GetComponent<Ball>().immuneTime = 0.25f;
                temp1.transform.position = transform.position + Vector3.left; 
                temp1.transform.localScale = transform.localScale/2; 
                GameObject temp2 = Instantiate(gameObject, transform.position, transform.rotation);
                temp2.GetComponent<Ball>().initSpeed = new Vector2( (Mathf.Abs(currentSpeed.x)) * 1.1f,(Mathf.Abs(currentSpeed.y)) * 1.1f);
                temp2.GetComponent<Ball>().immuneTime = 0.25f;
                temp2.transform.position = transform.position + Vector3.right; 
                temp2.transform.localScale = transform.localScale/2;
            }
            Destroy(gameObject);
        }
    }
}
