using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_mario_finalminigame
{
public class AmuchalipsisRabbit : MonoBehaviour
{  
    public GameObject Blood;
    public GameObject Body;

    private float VerticalInput=0F;
    private float HorizontalInput=0F;
    private bool dead=false;

    // Update is called once per frame
    private void Start() {
        InvokeRepeating("ChooseNewInputs",1F,5F);
    }
    void Update()
    {

         if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1))
             Die();
        if(!dead)
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(5F,gameObject.transform.position-new Vector3(VerticalInput,-0.5F,HorizontalInput),10,0,ForceMode.Force);
            //Debug.Log("moving");
       
    }
    public void Die(){
        Rigidbody[] BloodBoxParticles=Blood.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody BloodBox in BloodBoxParticles){
            BloodBox.constraints=RigidbodyConstraints.None;
            //BloodBox.AddForce(Random.Range(-5F,5F),10,Random.Range(-5F,5F),ForceMode.Impulse);
            BloodBox.AddExplosionForce(10,(BloodBox.gameObject.transform.position-new Vector3(Random.Range(-1F,1F),5,Random.Range(-1F,1F))),10F,1F,ForceMode.Impulse);
           
        }
        Instantiate(Resources.Load("Amuchalipsis/BloodPart") as GameObject,gameObject.transform.position-new Vector3(0,0.2F,0),new Quaternion());
        gameObject.GetComponent<BoxCollider>().enabled=false;
        gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
        //gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        Body.transform.localScale=new Vector3(1,0.1f,1);
        Body.transform.localPosition= new Vector3(0,0.01F,0);
        gameObject.transform.rotation=new Quaternion();
        dead=true;
        //gameObject.transform.localScale=new Vector3(1,0.1F,1);

        //gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-5F,5F),10,0,ForceMode.Impulse);
        
    }
    private void ChooseNewInputs(){
        VerticalInput=Random.Range(-1,2);
        HorizontalInput=Random.Range(-1,2);
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            Die();
        }
    }
}
}
