using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XavierRibasDeTorres2
{
    public class BulletManager : MonoBehaviour
    {
        public GameObject GameMan;

        private Rigidbody rgbBala;
        private Transform Bala;
        private float horit;
        private float vert;
        public float vel;
        private BulletGuide Gamescript;
    
    // Start is called before the first frame update
    void Start()
        {
            Bala = GetComponent<Transform>();
            rgbBala = GetComponent<Rigidbody>();
            vel = 3f;
            Gamescript = GameMan.GetComponent<BulletGuide>();
        }

        // Update is called once per frame
        void Update()
        {


            horit = InputManager.Instance.GetAxisHorizontal();
            vert = InputManager.Instance.GetAxisVertical();

            if (horit > 0)
            {
                Bala.Rotate(0, 1, 0);
            }
            else if (horit < 0)
            {
                Bala.Rotate(0, -1, 0);
            }
            else
            {
                Bala.Rotate(0, 0, 0);
            }

            if (vert < 0)
            {
                Bala.Rotate(1, 0, 0);
            }
            else if (vert > 0)
            {
                Bala.Rotate(-1, 0, 0);
            }
            else
            {
                Bala.Rotate(0, 0, 0);
            }
            Vector3 move = Bala.rotation * Vector3.forward;
            rgbBala.velocity = move * vel;
            
        }

        void OnCollisionEnter (Collision coll)
        {
            if(coll.collider.tag == "Walls")
            {
                Gamescript.Lose();
            }
            
            else
            {
                Gamescript.Win();
            }

            
        }
    }

}