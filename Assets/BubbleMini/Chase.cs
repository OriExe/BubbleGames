using UnityEditor;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject Player;
    public GameObject Heli;
    public float Speed = 9;
    private float Distance;
    // Update is called once per frame
    void Start()
    {
        // Automatically find the Heli object if it's not set in the inspector
        if (Heli == null)
        {
            Heli = GameObject.FindWithTag("Heli");  // Make sure your Heli GameObject has the "Heli" tag
        }
    }
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 Direction = Player.transform.position - transform.position;
        Direction.Normalize();
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        // When the Player enters range of the Enemy they begin relentlessly chasing after the Player
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet")) {
            if (Heli != null)
            {
                Land landScript = Heli.GetComponent<Land>();
                if (landScript != null)
                {
                    Debug.Log("Yes");
                    landScript.Kill();  // Increase the kill count
                }
            }
            else {
                Debug.Log("Nope");
            }
        }
    }
}
    
