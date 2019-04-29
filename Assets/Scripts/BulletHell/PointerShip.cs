using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XavierRibasDeTorres
{
    public class PointerShip : MonoBehaviour
    {

        private Vector3 mousePos;
        private float PosX;
        private float PosY;
        private Vector3 GameMousePos;


        void Start()
        {
            PosX = InputManager.Instance.GetAxisHorizontal2();
            PosY = InputManager.Instance.GetAxisVertical2();

        }


        // Update is called once per frame
        void Update()
        {

             if (PosX > 0)
            {

                transform.Translate(-0.5f, 0, 0);
            }
            else if (PosX < 0)
            {
                transform.Translate(0.5f, 0, 0);
            }
            else
            {
                transform.Translate(0, 0, 0);
            }


            if (PosY > 0)
            {

                transform.Translate(0, -0.5f, 0);
            }
            else if (PosY < 0)
            {
                transform.Translate(0, 0.5f, 0);
            }
            else
            {
                transform.Translate(0, 0, 0);
            }



            mousePos = Input.mousePosition;

            GameMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            GameMousePos.z = -45;
            transform.position = Vector2.Lerp(transform.position, GameMousePos, 0.6f);
        }
    }
}