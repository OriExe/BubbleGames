using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject MC;
    public GameObject Heli;
    private Health HealthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            }
            // The Bullet is destroyed along with the Enemy it hits
            if (other.gameObject.tag == "Ground")
            {
                Destroy(gameObject);
            }
            // Bullet is destroyed when it hits a platform

        }
        void Start()
        {
            if (Heli == null)
            {
                Heli = GameObject.FindWithTag("Heli");
            }
            HealthScript = MC.GetComponent<Health>();
            Destroy(gameObject, 3f);
        }
        // The bullet is destroyed 3 seconds after being shot
    }
