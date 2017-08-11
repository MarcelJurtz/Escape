using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text instructionText;

    private bool isMoving = false;
    private Rigidbody playerBody;
    private Transform playerTransform;
    private Vector3 startPosition;
    private const int speed = 1000;
    private const int respawnRateInSeconds = 1;

	void Start ()
    {
        playerBody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        startPosition = playerTransform.position;
    }
	
	void Update ()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerBody.AddForce(0, speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerBody.AddForce(0, -speed, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerBody.AddForce(-speed, 0, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerBody.AddForce(speed, 0, 0);
                isMoving = true;
                InvokeRepeating("respawnPlayer", respawnRateInSeconds, 0);
            }
        }
    }

    void respawnPlayer()
    {
        MovementAllowed allowedDirections = MovementLimits.getRandomRestriction();
        instructionText.text = allowedDirections.getTitle();

        playerBody.velocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;
        playerTransform.position = startPosition;
        isMoving = false;
    }
}
