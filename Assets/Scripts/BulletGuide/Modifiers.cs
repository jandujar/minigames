using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XavierRibasDeTorres2
{
    

    
    public class Modifiers : MonoBehaviour
    {
        public GameObject Bala;

        private BulletManager Balascript;
        // Start is called before the first frame update
        void Start()
        {
            Balascript = Bala.GetComponent<BulletManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider coll)
        {
            if (gameObject.name == "AddVelocity")
            {
                Debug.Log("+vel");
                Balascript.vel += 1;
            }
            else
            {
                Debug.Log("-vel");
                if (Balascript.vel > 1)
                {
                    Balascript.vel -= 1;
                }
            }
            Destroy(gameObject);
            
        }
    }
}
