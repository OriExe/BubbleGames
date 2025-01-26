using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Audio;

public class Shoot : MonoBehaviour
{
    private Camera camera;
    private Vector3 MousePosition;
    public GameObject Bullet;
    public Transform BulletTransform;
    public bool CanFire;
    private float Timer;
    public float TimeBetweenShots = .005f;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Rotation = MousePosition - transform.position;
        float RotationZ = Mathf.Atan2(Rotation.y, Rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Rotation.z);
        if (Input.GetMouseButton(0) && CanFire)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
            animator.SetBool("Shot", true);
        }
        //When the player clicks the left mouse button a bullet is shot in the aimed direction

        if (!CanFire)
        {
            Timer += Time.deltaTime;
            if (Timer > TimeBetweenShots)
            {
                CanFire = true;
                Timer = 0;
                animator.SetBool("Shot", false);
                animator.Play("Idle");
            }
            // After a certain amount of time the character will transition from the Shooting pose to the Idle Pose
        }
    }
}
