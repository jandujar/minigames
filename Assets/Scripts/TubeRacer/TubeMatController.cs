using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMatController : MonoBehaviour
{
    [SerializeField] float speed, offset;
    [SerializeField] MeshRenderer meshRend;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        meshRend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);//SetTextureOffset("Offset", new Vector2(offset, 0));
    }
}
