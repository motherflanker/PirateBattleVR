using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPointGenerator : MonoBehaviour
{
    public static Vector3 RandomPointGen (Vector3 start, float radius)
    {
        Vector3 Dir = Random.insideUnitSphere * radius;
        Dir += start;
        NavMeshHit hit_;
        Vector3 finalPos = Vector3.zero;
        if(NavMesh.SamplePosition(Dir, out hit_, radius, 1))
        {
            finalPos = hit_.position;
        }
        return finalPos;
    }
}
