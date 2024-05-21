using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public HomeScreen homeScreen;

    public GameObject[] animalPrefabs;
    private Vector3[] lanePositions;
    private float[] spawnTimers;

    //private float spawnRangeX = 10;
    //private float spawnPosZ = 20;

    private float startDelay;
    private float spawnInterval;

    //private int animalIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(homeScreen.GameMode == 1)
        {
            startDelay = 4.25f;
            spawnInterval = 3.0f;
        }
        else if (homeScreen.GameMode == 2)
        {
            startDelay = 3.75f;
            spawnInterval = 2.5f;
        }
        else if (homeScreen.GameMode == 3)
        {
            startDelay = 3.5f;
            spawnInterval = 2.0f;
        }
        else
        {
            Debug.Log("GameMode Error!");
        }

        lanePositions = new Vector3[]
        {
        new Vector3(-10, 0, 20),
        new Vector3(0, 0, 20),
        new Vector3(10, 0, 20)
        };

        //InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

        spawnTimers = new float[animalPrefabs.Length];

        for (int i = 0; i < spawnTimers.Length; i++)
        {
            spawnTimers[i] = startDelay + i * spawnInterval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance != null && !UIManager.Instance.IsGameOver())
        {
            for (int i = 0; i < lanePositions.Length; i++)
            {
                spawnTimers[i] -= Time.deltaTime;
                if (spawnTimers[i] <= 0)
                {
                    SpawnAnimalInLane(i);
                    spawnTimers[i] = startDelay + i * spawnInterval;
                }
            }
        }
    }

    void SpawnAnimalInLane(int Index)
    {
        Vector3 spawnPos = lanePositions[Index];
        Instantiate(animalPrefabs[Index], spawnPos, animalPrefabs[Index].transform.rotation);
    }

    //void SpawnRandomAnimal()
    //{
    //    if (UIManager.Instance != null && !UIManager.Instance.IsGameOver())
    //    {
    //        if (animalIndex < animalPrefabs.Length-1)
    //        {
    //            animalIndex++;
    //        }
    //        else
    //        {
    //            animalIndex = 0;
    //        }
    //        //int animalIndex = Random.Range(0, animalPrefabs.Length);
    //        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    //        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    //    }
    //}
}