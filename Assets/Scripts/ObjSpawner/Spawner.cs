using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public Transform spawnPoint;
    public void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objects.Length);
        GameObject randomObject = GameObject.Instantiate(objects[randomIndex]);
        randomObject.transform.position = spawnPoint.position;
        randomObject.GetComponent<ObjectMover>().move = true;
    }
}
