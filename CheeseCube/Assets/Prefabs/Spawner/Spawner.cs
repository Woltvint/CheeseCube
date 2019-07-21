using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject thingToSpawn;
    public float spawnInterval;

    private float time = 0;

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time >= spawnInterval)
        {
            Instantiate(thingToSpawn,transform.position,transform.rotation);
            time = 0;
        }
    }
}
