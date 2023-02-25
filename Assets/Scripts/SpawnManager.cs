using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawner spawner;
    public float spawnTime = 160/60;
    public bool spawnEnabled = false;
    public float spawnRate = 0/1;

    // Delay Logic
    private float timeSinceLastSpawn = 0f;


    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn < spawnTime) return;
        if (!spawnEnabled) return;

        spawner.SpawnRandomObject();

    }
}
