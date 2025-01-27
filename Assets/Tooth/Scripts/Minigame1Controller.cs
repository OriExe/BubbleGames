using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class Minigame1Controller : MonoBehaviour
{
    public int pointCounter = 0;
    public int victoryCount = 100;
    public bool addPoint = false;
    public bool gameOver = false;

    public float timer = 0;
    public int elapsedTime;
    public int maxTime = 20;

    public float spawnAreaWidth = 2.18f;
    public float spawnAreaHeight = 1.16f;
    public GameObject bubblePrefab;

    private List<GameObject> spawnedBubbles = new List<GameObject>();
    public GameObject minigame;

    public GameObject backgroundIMG;
    int teethState = 0;
    public Sprite[] teethSprites;

    public AudioSource audioSource;
    public AudioClip bubbling;
    public List<AudioClip> popBubbles = new List<AudioClip>();

    public GameObject victoryCanvas;
    public Text victoryText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= maxTime)
        {

            if (gameOver == false)
            {
                victoryCanvas.SetActive(true);
                victoryText.text = "Your Points :" + pointCounter;
                gameOver = true;

                minigame.SetActive(false);
            }
        }
        else
        {
            if (addPoint == true)
            {
                //Debug.Log("pointcounter: " + pointCounter + "Remainder: " + pointCounter % 20);
                if (pointCounter % 20 == 0)
                {

                    if (backgroundIMG != null && teethState < teethSprites.Length)
                    {
                        SpriteRenderer teeth = backgroundIMG.GetComponent<SpriteRenderer>();

                        teeth.sprite = teethSprites[teethState];

                        Debug.Log(teeth.sprite);
                        
                    }
                    teethState++;
                    DestroyBubbles();
                }
                pointCounter++;

                SpawnBubble();

                addPoint = false;
            }
        }
        

    }

    private void FixedUpdate()
    {
        if (elapsedTime < maxTime)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                elapsedTime++;
                //Debug.Log(elapsedTime);
                if (elapsedTime > maxTime)
                {
                    if (pointCounter >= victoryCount)
                    {
                        Debug.Log("YOU WIN!");
                    }
                    else
                    {
                        Debug.Log("GAME OVER");
                    }

                }
            }
        }


    }

    void SpawnBubble()
    {
        // Get the main camera's position and camera boundaries
        Camera mainCamera = Camera.main;

        // Camera's viewport dimensions (World space)
        float cameraWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect; // Width of the camera's view in world space
        float cameraHeight = mainCamera.orthographicSize * 2f; // Height of the camera's view in world space

        float randomX = Random.Range(mainCamera.transform.position.x - spawnAreaWidth / 2f, mainCamera.transform.position.x + spawnAreaWidth / 2f);
        float randomY = Random.Range(mainCamera.transform.position.y - spawnAreaHeight / 2f, mainCamera.transform.position.y + spawnAreaHeight / 2f);


        Vector2 randomPosition = new Vector2(randomX, randomY);

        GameObject bubble = Instantiate(bubblePrefab, randomPosition, Quaternion.identity);

        spawnedBubbles.Add(bubble);

        float randomScale = Random.Range(0.1f, 0.8f);

        bubble.transform.localScale = new Vector2(randomScale, randomScale);




        if (pointCounter % 20 == 0)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else if (!audioSource.isPlaying)
        {
            float randomPitch = Random.Range(0.8f, 1.2f);
            audioSource.pitch = randomPitch;
            audioSource.PlayOneShot(bubbling);
        }



        // issue probably is: doesn't have a location so it doesn't know where to spawn it. Or there's too much in this script.
    }

    void DestroyBubbles()
    {

        foreach (GameObject bubble in spawnedBubbles)
        {
            if (bubble != null) Destroy(bubble);
            float randomPitch = Random.Range(0.8f, 1.2f);
            int randomIndex = Random.Range(0, popBubbles.Count);
            AudioClip randomFile = popBubbles[randomIndex];
            audioSource.pitch = randomPitch;
            audioSource.PlayOneShot(randomFile);
        }
        spawnedBubbles.Clear();
    }
}
