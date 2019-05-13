using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolos
{
    public class BolaFuera : MonoBehaviour
    {
        public GameObject Juego;

        private Bowling Bolosscript;
        private float time;
        private float seconds;
        private bool ready;
        private bool starttime;

        // Start is called before the first frame update
        void Start()
        {
            ready = false;
            starttime = false;
            time = 0;
            seconds = 0;
            Bolosscript = Juego.GetComponent<Bowling>();
        }

        // Update is called once per frame
        void Update()
        {
            if(starttime == true)
            {
                time += Time.deltaTime;
                seconds = (int)time % 60;
                if(seconds == 3)
                {
                    
                    ready = true;
                }
            }

            if(ready == true)
            {
                Bolosscript.Next();
            }
            
        }
        void OnTriggerEnter(Collider col)
        {
            if(col.name == "Bola")
            { 
             starttime = true;
            }
        }

        public void restart()
        {
            time = 0;
            seconds = 0;
            starttime = false;
            ready = false;
        }
    }

}