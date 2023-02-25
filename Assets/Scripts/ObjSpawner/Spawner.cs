using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public Vector3 spawnOffset = Movement.startPostion;
    public float offset = Movement.offset;

    void Start()
    {
        spawnOffset.z = -21.5f;
    }
    public void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objects.Length);
        int rndPos = Random.Range(0, 5);
        GameObject randomObject = GameObject.Instantiate(objects[randomIndex]);
        randomObject.transform.position = spawnOffset + new Vector3( -rndPos * offset, 0, 0);
        randomObject.GetComponent<ObjectMover>().move = true;
    }
    void SpawnRandomRow(int numOfObjects)
    {
        int randomIndex = Random.Range(0, objects.Length);
        int[] takenPositions = new int[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            int rndPos = Random.Range(0, 5);
            while (takenPositions.Contains(rndPos))
            {
                rndPos = Random.Range(0, 5);
            }
            takenPositions[i] = rndPos;
            GameObject randomObject = GameObject.Instantiate(objects[randomIndex]);
            randomObject.transform.position = spawnOffset + new Vector3( -rndPos * offset, 0, 0);
            randomObject.GetComponent<ObjectMover>().move = true;
        }
    }
}
