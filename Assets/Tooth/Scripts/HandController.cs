using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{

    public GameObject hand;
    public GameObject leftMouth;
    public GameObject rightMouth;
    public GameObject gameController;
    CircleCollider2D palm;
    BoxCollider2D leftTrigger;
    BoxCollider2D rightTrigger;

    private Minigame1Controller gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        palm = GetComponent<CircleCollider2D>();
        leftTrigger = GetComponent<BoxCollider2D>();
        rightTrigger = GetComponent<BoxCollider2D>();

        gameControllerScript = gameController.GetComponent<Minigame1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Status status = collision.GetComponent<Status>();
        if (status.exhausted == false)
        {
            gameControllerScript.addPoint = true;
            status.exhausted = true;
            if (collision.gameObject == leftMouth)
            {
                Status otherStatus = rightMouth.GetComponent<Status>();
                otherStatus.exhausted = false;
                //Debug.Log(rightMouth + " Ready!"); // check its changing the correct thing
            }
            else
            {
                Status otherStatus = leftMouth.GetComponent<Status>();
                otherStatus.exhausted = false;
                //Debug.Log(leftMouth + " Ready!"); // check again its changing the correct thing
            }

        }
    }
}
