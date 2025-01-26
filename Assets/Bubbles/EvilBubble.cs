using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBubble : MonoBehaviour
{
    private BubbleSpawn.spawnLocation spawnedFrom = BubbleSpawn.spawnLocation.none;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float FowardSpeed;
    [SerializeField] private float upSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManagerScript.instance.endGame();
        }
    }

    public void whereBubbleSpawnedfrom(BubbleSpawn.spawnLocation location)
    {
        spawnedFrom = location;
        switch (spawnedFrom)
        {
            case BubbleSpawn.spawnLocation.left:
                tag = "Left";
                break;
            case BubbleSpawn.spawnLocation.right:
                tag = "Right";
                break;
        }
        switchTag();
    }

    private void switchTag()
    {

        switch (tag)
        {
            case "Right":
                spawnedFrom = BubbleSpawn.spawnLocation.right;
                break;
            case "Left":
                spawnedFrom = BubbleSpawn.spawnLocation.left;
                break;
        }

    }

    private void Update()
    {
        //Is Null
        if (spawnedFrom == BubbleSpawn.spawnLocation.none)
        {
            switchTag();
        }

        if (spawnedFrom == BubbleSpawn.spawnLocation.left)
        {
            rb.velocity = new Vector2(FowardSpeed, upSpeed);

        }
        else if (spawnedFrom == BubbleSpawn.spawnLocation.right)
        {
            rb.velocity = new Vector2(-FowardSpeed, upSpeed);
        }
    }
}
