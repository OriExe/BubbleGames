using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject clonePrefab;  // The prefab of the object to spawn
    public float spawnRadius = 2f;  // The distance at which clones spawn from the original
    public int numberOfClones = 3; // The number of clones to spawn
    public float cloneScaleFactor = 0.5f; // The scale factor for the clones
    private float minSize; //If below size bubble won't spawn
    private void OnMouseDown()
    {
        SpawnClones();

    }

   
    void SpawnClones()
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject clone = Instantiate(clonePrefab, spawnPosition, Quaternion.identity);

            // Scale the clone smaller
            clone.transform.localScale *= cloneScaleFactor;
        }

        Destroy(gameObject);
    }
}
