using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public List<Transform> BodyParts = new List<Transform>();
    public float mindistance = 0.25f;

    public GameObject body;
    public int beginsize;
    public float Speed = 1f;
    public float roation = 50;
    public float r = Input.GetAxis("Horizonatal");
    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;
    
	// Use this for initialization
	void Start () {

        for (int i = 0; i < beginsize - 1; i++)
        {
            AddBodyPart();
        }

	}
	
	// Update is called once per frame
	void Update () {

        Move();

        if (Input.GetKey(KeyCode.W))
        {
            AddBodyPart();
        }

	}

    public void Move()
    {
        float curspeed = speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            curspeed *= 2;
        }

        BodyParts[0].Translate(BodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);

        if( r != 0)
        {
            BodyParts[0].Rotate(Vector3.up * roation * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        for(int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            PrevBodyPart = BodyParts[i - 1];

            dis = Vector3.Distance(PrevBodyPart.position, curBodyPart.position);

            Vector3 newpos = PrevBodyPart.position;
            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis / mindistance * curspeed;

            if(T > 0.5f)
            {
                T = 0.5f;
            }

            curBodyPart.position = Vector3.Slerp(curBodyPart.position,newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation,PrevBodyPart.rotation, T);
        }
    }

    public void AddBodyPart()
    {

        Transform newpart = (Instantiate(body, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newpart.SetParent(transform);
        BodyParts.Add(newpart);

    }
}
