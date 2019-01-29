using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XavierRibasDeTorres
{
    public class BulletShip : MonoBehaviour
    {
        public float timelife;
        public float VelDisp;

        private GameObject GameMan;
        private GameObject Player;
        private BulletHell bullscript;

        

        // Update is called once per frame
        void Update()
        {
            


            //transform.position = Vector2.MoveTowards(transform.position, bulldisp, VelDisp * Time.deltaTime);



            timelife -= Time.deltaTime;
            if (timelife <= 0)
            {
                Destroy(gameObject);
            }
        }
        void OnCollisionEnter2D(Collision2D coll)
        {

            Destroy(gameObject);
        }

    }
}