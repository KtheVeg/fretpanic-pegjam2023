using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] powups;
    public Vector3 spawnOffset = Movement.startPostion;
    public float offset = Movement.offset;
    public float replacementChance = 0.5f;
    public float randomSpeedModifierLow = 10f;
    public float randomSpeedModifierHigh = 10f;

    void Start()
    {
        spawnOffset.z = -21.5f;
    }
    public void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objects.Length);
        int rndPos = Random.Range(0, 6);
        GameObject randomObject = GameObject.Instantiate(objects[randomIndex]);
        randomObject.transform.position = spawnOffset + new Vector3( -rndPos * offset, 0, 0);
        randomObject.GetComponent<ObjectMover>().move = true;
    }
    public void SpawnRandomRow(int numOfObjects)
    {
        int[] takenPositions = new int[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            int rndPos = Random.Range(0, 6) + 1;
            while (takenPositions.Contains(rndPos+1))
            {
                rndPos = Random.Range(0, 6) + 1;
            }
            takenPositions[i] = rndPos + 1;
        }

        // Individual objects
        for (int i=0; i < numOfObjects; i++) {
            if (Random.Range(1,30) == 1)
            {
                int rndInd = Random.Range(0,3);
                GameObject powup = GameObject.Instantiate(powups[rndInd]);
                powup.transform.position = spawnOffset + new Vector3( -(takenPositions[i]-2) * offset, 0, 0);
                powup.GetComponent<ObjectMover>().move = true;
                powup.GetComponent<ObjectMover>().speed = Random.Range(randomSpeedModifierLow,randomSpeedModifierHigh);
            } else {
                int randomIndex = Random.Range(0, objects.Length);
                GameObject randomObject = GameObject.Instantiate(objects[randomIndex]);
                randomObject.transform.position = spawnOffset + new Vector3( -(takenPositions[i]-2) * offset, 0, 0);
                randomObject.GetComponent<ObjectMover>().move = true;
                randomObject.GetComponent<ObjectMover>().speed = Random.Range(randomSpeedModifierLow,randomSpeedModifierHigh);
            }
            
        }
    }
}
