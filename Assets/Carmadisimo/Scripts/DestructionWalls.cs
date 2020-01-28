using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionWalls : MonoBehaviour
{
    float timer;

  void Start()
  {
      timer = 1f;
  }

  void Update()
  {
    timer -= Time.deltaTime;
    if(timer <= 0){
        GameObject.Destroy(gameObject);
    }
  }
}
