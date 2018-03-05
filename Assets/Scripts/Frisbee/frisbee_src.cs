using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class frisbee_src : MonoBehaviour {

    public float speed;
    public GameObject dog;

    private bool shoot;
    private float Xspeed;
    private float Yspeed;
    private float angle;
    private float x;
    private float y;
    private float z;
    private float gravity;



    void Start()
    {
        shoot = false;
        gravity = 9.8f;
        angle = 45f;
        x = 0;
        y = 0;
        z = 0;
}

    void Update()
    {
        //Debug.Log(transform.position.y);
        if (shoot)
        {
            GetComponent<Rigidbody>().useGravity = true;
            x = Xspeed * Time.deltaTime;
            y = Yspeed * Time.deltaTime - (gravity * Mathf.Sqrt(Time.deltaTime)) / 2;
            transform.Translate(x, y, z);
        }else
        {
            GetComponent<Rigidbody>().useGravity = false;;
        }
        if(transform.position.y <=  7)
        {
            dog.GetComponent<dog_src>().LooseGame();
        }
    }

    public void setShoot(bool set)
    {
        shoot = set;
    }

    public void setAngle(float newAngle)
    {
        angle = newAngle;
        CalculateAngle();
    }
    void CalculateAngle()
    {
        float sin = Mathf.Sin((angle * Mathf.PI) / 180);
        float cos = Mathf.Cos((angle * Mathf.PI) / 180);
        Xspeed = speed * sin;
        Yspeed = speed * cos;
    }

    // x=x0+v0t+12at2

}
