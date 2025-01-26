using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 MousePosition;
    private Camera Camera;
    private Rigidbody2D rb;
    public float MuzzelVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 
        rb = GetComponent<Rigidbody2D>();
        MousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Direction = MousePosition - transform.position;
        Vector3 Rotation = transform.position - MousePosition;
        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * MuzzelVelocity;
    }
    // When player clicks bullets instantiates at the triangle muzzel of the gun and shoots in the direction of the mouse cursor
}
