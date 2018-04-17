using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(BallsSpawner))]
public class BallsSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        BallsSpawner l_BallSpawn = (BallsSpawner)target;
        if(GUILayout.Button("Spawn Balls"))
        {
            spawnTargets(l_BallSpawn);
        }

    }
    
    void spawnTargets(BallsSpawner _spawner)
    {
        for (int i = 0; i < _spawner.m_BallCount; ++i)
        {
            Vector3 l_Pos = (Random.onUnitSphere * _spawner.m_Radius) + new Vector3(0, 0, -10);
            if (l_Pos.x > -8.5f && l_Pos.x < 8.5f && l_Pos.y > 0.25f && l_Pos.y < 6.5f && l_Pos.z > -8)
                Instantiate(_spawner.m_Object, l_Pos, Quaternion.identity, _spawner.m_Parent);
        }
    }
}
#endif