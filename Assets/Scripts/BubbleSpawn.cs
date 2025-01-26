using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public enum spawnLocation {left, right, none};

    [SerializeField] private spawnLocation spawner;
    [SerializeField] private GameObject bubbles;
    [SerializeField] private GameObject evilBubble;

    [SerializeField] private float spawnDelay;
    private float timeleft;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            int random = Random.Range(0, 6);

            if (random != 3)
            {
                GameObject temp = Instantiate(bubbles, transform.position, Quaternion.identity);
                temp.GetComponent<BubbleScript>().whereBubbleSpawnedfrom(spawner);
                
            }
            else
            {
                GameObject temp = Instantiate(evilBubble, transform.position, Quaternion.identity);
                temp.GetComponent<EvilBubble>().whereBubbleSpawnedfrom(spawner);
            }
            timeleft = spawnDelay;
        }
    }
}
