using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float HorizontalMove = 0f;
    bool OnTheGround;
    float RunSpeed = 19f;
    float JumpForce = 25f;
    bool FacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    public Animator animator;
    public GameObject Player;
    private float FallHeight = -10f;
    private float DeathBed = -10f;
    // Character variables
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        // read horizontal keyboard input and store it in HorizontalMove

        if (Input.GetButtonDown("Jump") && OnTheGround) {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            OnTheGround = false;
            animator.SetBool("Jumping", true);
        } 
        // Jumping animation starts when player presses space when they're on the floor
        

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
        // if player presses space the character jumps, they can also jump higher if they hold the jump button
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        // Animator will play the running animation when the float Speed parameter is above .01f
        Flip();
        // Flips the character horizontally if they start moving in the opposite horizontal direction
    }
    // Update is called once per frame


    void FixedUpdate()
    {
        rb.velocity = new Vector2(HorizontalMove * RunSpeed, rb.velocity.y);
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetBool("Idle", true);
        }
        if (transform.position.y < DeathBed)
        {
            SceneManager.LoadSceneAsync("Game Over Screen");
        }

    }
    private void OnCollisionEnter2D(Collision2D Ground)
    {
        if (Ground.gameObject.CompareTag("Ground")) {
            OnTheGround = true;
            animator.SetBool("Jumping", false);
        }
    }
    private void Flip() { 
        if(FacingRight && HorizontalMove < 0f || !FacingRight && HorizontalMove > 0f) {
            FacingRight = !FacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
