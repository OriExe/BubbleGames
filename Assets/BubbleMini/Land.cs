using UnityEngine;

public class Land : MonoBehaviour
{
    public float Speed = 2f;
    public float GroundLevel = 4f;
    public int KillCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (KillCount == 20) {
            Landing();
        }
    }
    public void Kill() { 
        KillCount++;
        Debug.Log("Killed " + KillCount);
    }
    public void Landing() {

        if (transform.position.y > GroundLevel) {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
            }
    }
