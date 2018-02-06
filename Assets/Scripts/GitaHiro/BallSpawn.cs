using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour {

    public enum m_Button{X,Y,A,B};
    public GameObject m_A;
    public GameObject m_B;
    public GameObject m_X;
    public GameObject m_Y;

    public GameObject m_SoundA;
    public GameObject m_SoundB;
    public GameObject m_SoundX;
    public GameObject m_SoundY;

    public Transform m_Parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log();
	}

    public IEnumerator generateRandom(float _time, int _maxValue, int _minValue)
    {
        int l_NotesCount = 0;
        int l_TotalNotes = 0;
        while (true)
        {
            yield return new WaitForSecondsRealtime(_time);
            int l_Rand = Random.Range(_minValue, _maxValue);
            l_NotesCount++;
            l_TotalNotes++;
            Debug.Log("Value: "+l_Rand+" - Note num: "+l_NotesCount+" - Time: "+_time+" - Total notes: "+l_TotalNotes);
            switch(l_Rand)
            {
                case 1:
                    Instantiate(m_SoundX, m_X.transform.position, Quaternion.identity, m_Parent);
                    break;
                case 2:
                    Instantiate(m_SoundY, m_Y.transform.position, Quaternion.identity, m_Parent);
                    break;
                case 3:
                    Instantiate(m_SoundA, m_A.transform.position, Quaternion.identity, m_Parent);
                    break;
                case 4:
                    Instantiate(m_SoundB, m_B.transform.position, Quaternion.identity, m_Parent);
                    break;
            }
            if(l_NotesCount>=5)
            {
                if(_time>0.65f)
                {
                    _time -= 0.15f;
                    l_NotesCount = 0;
                }
            }            
        }
    }
}
