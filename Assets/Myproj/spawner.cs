using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objectToSpawn;


    public float timeToSpawn;
    private float currentTimeToSpawn;




    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject(); 
            currentTimeToSpawn = timeToSpawn;
        }
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

}
