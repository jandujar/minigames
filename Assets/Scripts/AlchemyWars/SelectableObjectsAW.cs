using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ivan_alvarez_enri
{
public class SelectableObjectsAW : MonoBehaviour
    {
        public Elements _element;
        public bool selected=false;
        private Vector3 startPos;
        private void Start() {
            startPos=gameObject.transform.position;
            
        }
        public void SelectMe(){
            gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
            gameObject.transform.localScale=new Vector3(12,12,12);
            gameObject.GetComponent<AudioSource>().Play();
        }
        public void StopMe(){
            gameObject.GetComponent<SpriteRenderer>().color=new Color(0.764151F,0.764151F,0.764151F,1);
            gameObject.transform.localScale=new Vector3(10,10,10);
           
        }
        public void FinishMe(){
            gameObject.GetComponent<Animator>().SetTrigger("Die");
        }
        public void ImChoosed(){
            gameObject.GetComponent<Animator>().SetBool("Choosed",true);
        }
    }
}
