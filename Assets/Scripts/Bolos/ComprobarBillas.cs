using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolos
{
    public class ComprobarBillas : MonoBehaviour
    {
        public int BolosCant;
        public bool active;
        private bool activecount;
        private List<Collider> Bolos = new List<Collider>();


        // Start is called before the first frame update
        void Start()
        {
            BolosCant = 0;
            active = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(activecount == true)
            {
                
                BolosCant = Bolos.Count;
                

                activecount = false;
            }
            
            if(BolosCant != Bolos.Count)
            {


                BolosCant = Bolos.Count;

            }
        }
        void OnTriggerStay(Collider col)
        {
            
            if (active == true)
            {
                Debug.Log(active);
                if(!Bolos.Contains(col) && col.name == "Billas")
                {
                    Bolos.Add(col);
                    
                }
                
                activecount = true;
                
            }
        }

        public void activate()
        {
            
            active = true;
        }

        public void restart()
        {
            active = false;
            activecount = false;
            Bolos.Clear();
            
        }

    }
}

