using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XavierRibasDeTorres
{
    public class PointerShip : MonoBehaviour
    {

        private Vector3 mousePos;

        private Vector3 GameMousePos;




        // Update is called once per frame
        void Update()
        {


            mousePos = Input.mousePosition;

            GameMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            GameMousePos.z = -45;
            transform.position = Vector2.Lerp(transform.position, GameMousePos, 0.6f);
        }
    }
}