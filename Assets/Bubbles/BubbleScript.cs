using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;  // The prefab of the object to spawn
    [SerializeField] private float spawnRadius = 2f;  // The distance at which clones spawn from the original
    [SerializeField] private int numberOfClones = 3; // The number of clones to spawn
    [SerializeField] private float cloneScaleFactor = 0.5f; // The scale factor for the clones
    [SerializeField] private float minSize = 0.15f; //If below size bubble won't spawn

    [SerializeField] private float upSpeed;
    [SerializeField] private float FowardSpeed;

    private Transform airLocation;

    private Rigidbody2D rb;
    private void OnMouseDown()
    {
        SpawnClones();

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        airLocation = GameObject.FindGameObjectWithTag("Air").transform;
    }

    void SpawnClones()
    {
        if (minSize < transform.localScale.x)
        {
            for (int i = 0; i < numberOfClones; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                GameObject clone = Instantiate(clonePrefab, spawnPosition, Quaternion.identity);

                // Scale the clone smaller
                clone.transform.localScale *= cloneScaleFactor;
            }
        }
        Destroy(gameObject);
    }

    private void Update()
    {

        rb.velocity = new Vector2(FowardSpeed, upSpeed);
    }
}
