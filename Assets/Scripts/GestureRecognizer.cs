using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognizer : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isTouching = false;
    private Vector2 swipeStart, swipeDelta;
    private const int SWIPE_TOLERANCE = 250;

    private void resetSwipePosition()
    {
        swipeStart = Vector2.zero;
        swipeDelta = Vector2.zero;
        isTouching = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }

    private void Update()
    {
        tap = false;
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        // Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isTouching = true;
                swipeStart = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Ended)
            {
                isTouching = false;
                resetSwipePosition();
            }
        }

        // Distance Calculation
        swipeDelta = Vector2.zero;
        if(isTouching && Input.touches.Length > 0)
        {
            swipeDelta = Input.touches[0].position - swipeStart;         
        }

        // Swipe Recognition
        if(swipeDelta.magnitude > SWIPE_TOLERANCE)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                // Up or Down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            resetSwipePosition();
        }
    }
}
