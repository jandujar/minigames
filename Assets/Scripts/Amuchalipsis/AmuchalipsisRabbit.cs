using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuchalipsisRabbit : MonoBehaviour
{  
    public GameObject Blood;
    public GameObject Body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
        //     Die();
        if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON1)){
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(5F,gameObject.transform.position-new Vector3(1,-0.5F,0),10,0,ForceMode.Force);
            Debug.Log("moving");
        }
        if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON2)){
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(5F,gameObject.transform.position-new Vector3(-1,-0.5F,0),10,0,ForceMode.Force);
            Debug.Log("moving");
        }
        if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON3)){
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(5F,gameObject.transform.position-new Vector3(0,-0.5F,1),10,0,ForceMode.Force);
            Debug.Log("moving");
        }
        if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4)){
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(5F,gameObject.transform.position-new Vector3(0,-0.5F,-1),10,0,ForceMode.Force);
            Debug.Log("moving");
        }
    }
    public void Die(){
        Rigidbody[] BloodBoxParticles=Blood.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody BloodBox in BloodBoxParticles){
            BloodBox.constraints=RigidbodyConstraints.None;
            //BloodBox.AddForce(Random.Range(-5F,5F),10,Random.Range(-5F,5F),ForceMode.Impulse);
            BloodBox.AddExplosionForce(10,(BloodBox.gameObject.transform.position-new Vector3(Random.Range(-1F,1F),5,Random.Range(-1F,1F))),10F,1F,ForceMode.Impulse);
           
        }
        gameObject.GetComponent<BoxCollider>().enabled=false;
        gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
        Body.SetActive(false);
        //gameObject.transform.localScale=new Vector3(1,0.1F,1);

        //gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-5F,5F),10,0,ForceMode.Impulse);
        
    }
}
