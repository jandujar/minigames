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

        // Start is called before the first frame update
        void Start()
        {
            stop = false;
        }

        // Update is called once per frame
        void Update()
        {
            
               
                    sliderPower.value += 1;
               
                //if (sliderPower.value >= 100)
                //{
                //    sliderPower.value -= 1;
                //}
            Debug.Log(sliderPower.value);
        }
        
        public float Stop()
        {
            
            float power = sliderPower.value;
            return power;   
        }
    }

}