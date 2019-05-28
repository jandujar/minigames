using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ivan_mario_finalminigame 
{
    
    [RequireComponent(typeof(BoxCollider))]
    public class Amuchalipsis_Spawner : MonoBehaviour
    {
        public GameObject prefabToInstance;
        private BoxCollider regionToSpawn;
        public float maxTimeRespawn=5F;
        private float timeRespawn=0F;
        // Start is called before the first frame update
        void Start()
        {
            timeRespawn=Random.Range(0,maxTimeRespawn);
            regionToSpawn=GetComponent<BoxCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            timeRespawn-=Time.deltaTime;
            if(timeRespawn<0){
                Instantiate(prefabToInstance,
                    new Vector3(
                        Random.Range(transform.position.x,transform.position.x+regionToSpawn.size.x),
                        Random.Range(transform.position.y,transform.position.y+regionToSpawn.size.y),
                        Random.Range(transform.position.z,transform.position.z+regionToSpawn.size.z)
                ),Quaternion.Euler(0,0,0));
                timeRespawn=Random.Range(0,maxTimeRespawn);
            }
        }
    }
}
