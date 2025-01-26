using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private float timer;
    private float duration = .8f;
    private bool immune = false;
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDMG(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadSceneAsync("Game Over Screen");
        }
    }
    private void Update()
    {
        if (immune)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                immune = false;
                timer = 0f;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {   if (other.gameObject.CompareTag("Enemy") && !immune) {
            TakeDMG(.2f);
            immune = true;
        }
        if (other.gameObject.CompareTag("Heli")) {
            SceneManager.LoadSceneAsync("You Win Screen");
        }
        
    }
}
