using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oscar_vergara_jimenez2
{
    public class Shot : MonoBehaviour
    {
        float speed;
        GameObject chain;
        // Start is called before the first frame update
        void Start()
        {
            speed = 5f;
            chain = transform.GetChild(0).gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            chain.transform.localScale += Vector3.up * (speed / 2.25f);
            
        }
        void OnTriggerEnter2D(Collider2D other){
            if(other.name.ToLower().Contains("walls")){
                GameObject.Find("Player").GetComponent<Player>().shots--;
                Destroy(gameObject);
            }
        }
    }
}
