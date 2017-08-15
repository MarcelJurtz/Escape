using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text instructionText;
    public Text scoreText;

    private bool isMoving = false;
    private bool isLiving = true;
    private Rigidbody playerBody;
    private Transform playerTransform;
    private Vector3 startPosition;
    private const int speed = 1000;
    private const int respawnRateInSeconds = 1;

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
    }

    void Update()
    {
        if (!isMoving && isLiving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                instructionText.text = "";
                playerBody.AddForce(0, speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                instructionText.text = "";
                playerBody.AddForce(0, -speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                instructionText.text = "";
                playerBody.AddForce(-speed, 0, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
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
        }
    }

    public void kill()
    {
        isLiving = false;
        instructionText.text = "GAME OVER";
        HighscoreManager.setHighscore(score);
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
