using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject Platform;
    Vector3 lastPos;
    Vector3 pos;
    float size;
    
    void Start()
    {
        lastPos = transform.position;
        size = transform.localScale.x;
        for (int i = 0; i < 5; i++) 
        {
            SpawnX();
        }
        for (int i = 0; i < 5; i++)
        {
            SpawnZ();
        }
        for (int i = 0; i < 5; i++)
        {
            SpawnX();
        }
    }

   
    void Update()
    {
        
    }

    void SpawnX()
    {
        pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(Platform, pos, Quaternion.identity);

    }

    void SpawnZ()
    {
        pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(Platform, pos, Quaternion.identity);

    }
}
