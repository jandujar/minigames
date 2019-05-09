using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bolos
{
    public class BolaFuera : MonoBehaviour
    {
        public GameObject Juego;

        private Bowling Bolosscript;

        // Start is called before the first frame update
        void Start()
        {
            Bolosscript = Juego.GetComponent<Bowling>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
            Bolosscript.Next();
        }
    }

}