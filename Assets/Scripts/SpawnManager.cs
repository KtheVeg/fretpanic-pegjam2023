using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner spawner;
    public float spawnTime = 0.375f;
    public bool spawnEnabled = false;
    public float spawnRateLow = 1f;
    public float spawnRateHigh = 1f;

    // Delay Logic
    private float timeSinceLastSpawn = 0f;


    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn < spawnTime) return;
        timeSinceLastSpawn = 0f;
        if (!spawnEnabled) return;

        float numObj = Random.Range(spawnRateLow,spawnRateHigh);
        switch (numObj) {
            case >1:
            
        }


    }
}
