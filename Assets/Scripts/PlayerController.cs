using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text instructionText;
    public Text scoreText;

    public GestureRecognizer swipeControls;

    private bool isMoving = false;
    private bool isLiving = true;
    private Rigidbody playerBody;
    private Transform playerTransform;
    private Vector3 startPosition;
    private const int speed = 1000;
    private const int respawnRateInSeconds = 1;

    public Slider countdownSlider;
    private float timeInMilliSeconds = 3f;
    private float maxTime;
    private int score;

    private MovementAllowed allowedDirections;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        startPosition = playerTransform.position;
        score = 0;

        allowedDirections = MovementLimits.getRandomRestriction();
        instructionText.text = allowedDirections.getTitle();

        maxTime = timeInMilliSeconds;
        countdownSlider.value = 1;
    }

    void Update()
    {
        if (!isMoving && isLiving)
        {
            timeInMilliSeconds -= Time.deltaTime;
            countdownSlider.value = timeInMilliSeconds / maxTime;

            if (timeInMilliSeconds < 0)
            {
                kill();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || swipeControls.SwipeUp)
            {
                instructionText.text = "";
                playerBody.AddForce(0, speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || swipeControls.SwipeDown)
            {
                instructionText.text = "";
                playerBody.AddForce(0, -speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || swipeControls.SwipeLeft)
            {
                instructionText.text = "";
                playerBody.AddForce(-speed, 0, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || swipeControls.SwipeRight)
            {
                instructionText.text = "";
                playerBody.AddForce(speed, 0, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }
        }
    }

    void respawnPlayer()
    {
        if (isLiving)
        {
            allowedDirections = MovementLimits.getRandomRestriction();
            instructionText.text = allowedDirections.getTitle();

            playerBody.velocity = Vector3.zero;
            playerBody.angularVelocity = Vector3.zero;
            playerTransform.position = startPosition;
            isMoving = false;

            score++;
            scoreText.text = score.ToString("D2");

            timeInMilliSeconds = maxTime;
            countdownSlider.value = 1;
        }
    }

    public void kill()
    {
        isLiving = false;
        instructionText.text = "GAME OVER";
        HighscoreManager.setHighscore(score);

        // Destroy Score Text and center "Game Over"
        Destroy(scoreText);
        instructionText.transform.position = new Vector3(0, 0, 0);

        Destroy(countdownSlider.gameObject);
        this.gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine(WaitAndLoadMenu());  
    }

    public MovementAllowed getAllowedDirections()
    {
        return allowedDirections;
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(3);
        LevelLoader loader = new LevelLoader();
        loader.LoadMenuScene();
    }
}
