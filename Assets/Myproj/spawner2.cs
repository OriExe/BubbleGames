using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerAtDefinedLocations : MonoBehaviour
{
    // Array of prefabs to spawn
    public GameObject[] objectsToSpawn;

    // Array of predefined spawn positions
    public Vector2[] spawnLocations;

    // Time interval between spawns
    public float spawnInterval = 2f;

    private bool isSpawning = true;

    void Start()
    {
        // Start spawning at the defined interval
        InvokeRepeating("SpawnRandomObject", 0f, spawnInterval);
    }

    void SpawnRandomObject()
    {
        // Pick a random object from the array
        int randomObjectIndex = Random.Range(0, objectsToSpawn.Length);

        // Pick a random location from the predefined spawn locations array
        int randomLocationIndex = Random.Range(0, spawnLocations.Length);
        Vector2 spawnPosition = spawnLocations[randomLocationIndex];

        // Instantiate the selected object at the random location
        Instantiate(objectsToSpawn[randomObjectIndex], spawnPosition, Quaternion.identity);
    }
    public void StopSpawning()
    {
        isSpawning = false;
    }
}