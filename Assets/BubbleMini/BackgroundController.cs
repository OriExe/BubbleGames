using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; // Speed background moves relative to camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam || 1 = won't move

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
