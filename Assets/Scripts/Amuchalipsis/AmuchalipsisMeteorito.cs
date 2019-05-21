using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ivan_mario_finalminigame
{
    

public class AmuchalipsisMeteorito : MonoBehaviour
{
    public float rayRange=5000;
    
    private float Velocity=0;
    private GameObject CircleParticle;
 void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * rayRange;
        Gizmos.DrawRay(transform.position, direction);
    }
    void Start()
    {
        int layerMask = 1 << 9;
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.LogError(hit.collider.gameObject.name);
            CircleParticle=Instantiate(Resources.Load("Amuchalipsis/CircleCollisionPart"), hit.point-new Vector3(0,-0.2f,0), Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*rayRange , Color.yellow,2F);
            Debug.Log("Did Hit");
        }
        else
        {
            
           
            Destroy(gameObject);
           
        }

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.GetComponent<Amuchalipsis_Player>().lessStamina();
        }
    }
    private void OnCollisionEnter(Collision other) {
        Instantiate(Resources.Load("Amuchalipsis/ExplosionAsteroidParticle"),transform.position, Quaternion.Euler(-90,0,0));
        Explode();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity+=Time.deltaTime*0.1F;
        gameObject.transform.Translate((Vector3.forward)*Velocity);  
    }
    void Explode(){
        
        Destroy(CircleParticle);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
}
