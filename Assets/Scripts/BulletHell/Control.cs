using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XavierRibasDeTorres
{
    public class Control : MonoBehaviour
    {
        public GameObject BulletHellObject;
        private BulletHell BulletHellScript;

        // Start is called before the first frame update
        void Start()
        {
            BulletHellScript = BulletHellObject.GetComponent<BulletHell>();
        }

        // Update is called once per frame
        void Update()
        {

            if (GameObject.FindGameObjectWithTag("EnemyShip") == null)
            {
                BulletHellScript.Win();
            }
        }
    }
}
