using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [Header("Spawn Times")]
    public float discountTime;
    public float minTimeSpawn;
    public int NotesCounted;
    [Header("Spawn Point")]
    public GameObject a;
    public GameObject b;
    public GameObject x;
    public GameObject y;
    [Header("Note")]
    public GameObject soundA;
    public GameObject soundB;
    public GameObject soundX;
    public GameObject soundY;
    [Header("Parent")]
    public Transform parent;
    
	public void GenerateRandomJand(float time, int minValue, int maxValue){
		StartCoroutine(generateRandom(time, minValue, maxValue));
	}

	public IEnumerator generateRandom(float _time, int _minValue, int _maxValue)
    {
        int notesCount = 0;
        while (true)
        {
            yield return new WaitForSecondsRealtime(_time);
            int l_Rand = Random.Range(_minValue, _maxValue);
            notesCount++;
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
            if(notesCount>=NotesCounted)
            {
                if(_time>minTimeSpawn)
                {
                    _time -= discountTime;
                    notesCount = 0;
                }
            }            
        }
    }
}
