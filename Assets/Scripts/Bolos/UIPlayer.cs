using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Bolos
{

    public class UIPlayer : MonoBehaviour
    {
        public bool stop;
        public Slider sliderPower;

        private enum Goto { Up, Down};
        private Goto GoNext;

        // Start is called before the first frame update
        void Start()
        {
            stop = false;
            GoNext = Goto.Up;
        }

        // Update is called once per frame
        void Update()
        {

            if(sliderPower.value == 5)
            {
                GoNext = Goto.Down;
            }
            if (sliderPower.value == 0)
            {
                GoNext = Goto.Up;
            }

            if (GoNext == Goto.Up)
            {
                sliderPower.value += 0.1F;
            }

            if(GoNext == Goto.Down)
            { 
            
                sliderPower.value -= 0.1F;
            }


           
        }
        
        public float Stop()
        {
            
            float power = sliderPower.value;
            return power;   
        }


    }

}