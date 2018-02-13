using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;

    public GameObject soundA;
    public GameObject soundB;
    public GameObject soundX;
    public GameObject soundY;

    public Transform parent;

    public bool spawnNotes = true;
    
    public IEnumerator generateRandom(float _time, int _maxValue, int _minValue)
    {
        int notesCount = 0;
        int totalNotes = 0;
        while (spawnNotes)
        {
            yield return new WaitForSecondsRealtime(_time);
            int l_Rand = Random.Range(_minValue, _maxValue);
            notesCount++;
            totalNotes++;
            Debug.Log("Value: "+l_Rand+" - Note num: "+notesCount+" - Time: "+_time+" - Total notes: "+totalNotes);
            switch(l_Rand)
            {
                case 1:
                    Instantiate(soundX, x.transform.position, Quaternion.identity, parent);
                    break;
                case 2:
                    Instantiate(soundY, y.transform.position, Quaternion.identity, parent);
                    break;
                case 3:
                    Instantiate(soundA, a.transform.position, Quaternion.identity, parent);
                    break;
                case 4:
                    Instantiate(soundB, b.transform.position, Quaternion.identity, parent);
                    break;
            }
            if(notesCount>=5)
            {
                if(_time>0.65f)
                {
                    _time -= 0.15f;
                    notesCount = 0;
                }
            }            
        }
    }
}
