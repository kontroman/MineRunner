using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private void Update()
    {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
        }

        if(swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
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
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
