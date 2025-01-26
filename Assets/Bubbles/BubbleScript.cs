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


    private BubbleSpawn.spawnLocation spawnedFrom = BubbleSpawn.spawnLocation.none;

    private Transform airLocation;

    [SerializeField]private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Audio in Score script
        {
            SpawnClones();
            ScoreSciptPopgame.SetScore(5f*1f/transform.localScale.x);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
 
        airLocation = GameObject.FindGameObjectWithTag("Air").transform;

   
    }

    void SpawnClones()
    {
        if (minSize < transform.localScale.x)
        {
            for (int i = 0; i < numberOfClones; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius; //Spawn around the sphere
                GameObject clone = Instantiate(clonePrefab, spawnPosition, Quaternion.identity);

                string tag = "Untagged";
                switch (spawnedFrom)
                {
                    case BubbleSpawn.spawnLocation.left:
                        tag = "Left";
                        break;
                    case BubbleSpawn.spawnLocation.right:
                        tag = "Right";
                        break;
                }
                clone.tag = tag;
                clone.transform.localScale *= cloneScaleFactor;
            }
        }
        Destroy(gameObject);
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
}
