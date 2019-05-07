using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolos
{
    public class BolaController : MonoBehaviour
    {

        private Rigidbody rgbBola;


        // Start is called before the first frame update
        void Start()
        {
            rgbBola = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void LauchBall(float force,Vector3 direction)
        {
            
            Vector3 directionforce = force * direction;

            rgbBola.AddForce(directionforce, ForceMode.Impulse);
        }
    }
}