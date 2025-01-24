using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public enum spawnLocation {left, right};

    [SerializeField] private spawnLocation spawner;
    [SerializeField] private GameObject bubbles;

    [SerializeField] private float spawnDelay;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            GameObject temp = Instantiate(bubbles, transform.position, Quaternion.identity);
            timeleft = spawnDelay;
        }
    }
}
