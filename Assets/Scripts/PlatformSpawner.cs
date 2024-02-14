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
        InvokeRepeating("SpawnPosition", 1f, 0.2f);
       
    }

   
    void Update()
    {
        if (GameObject.Find("Main Camera").GetComponent<CameraFollow>().gameOver)
        {
            CancelInvoke("SpawnPosition");
        }
    }

    void SpawnPosition()
    {
        int rand = Random.Range(0, 7);
        if (rand < 4)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
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
