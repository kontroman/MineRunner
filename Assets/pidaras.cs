using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pidaras : MonoBehaviour
{
    private bool center_left;
    private bool center_right;
    private bool left_center;
    private bool right_center;
    private bool jump;
    private bool backJump;
    private int lane = 2;

    public Swipe swipeControls;

    void Update()
    {
        if (swipeControls.SwipeLeft)
        {
            LEFT();
        }
        if (swipeControls.SwipeRight)
        {
            RIGHT();
        }
        if (swipeControls.SwipeUp)
        {
            JUMP();
        }
        if (center_left)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, PlayerController1.LeftPosition, Time.deltaTime * 9);
        }

        if (center_right)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, PlayerController1.RightPosition, Time.deltaTime * 9);
        }

        if (left_center)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, PlayerController1.CenterPosition, Time.deltaTime * 9);
        }
        if (right_center)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, PlayerController1.CenterPosition, Time.deltaTime * 9);
        }
        if (jump)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerController1.player.transform.position.x, 1.5f, PlayerController1.player.transform.position.z), Time.deltaTime * 9);
            StartCoroutine(StopJump());
        }
        if (backJump)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerController1.player.transform.position.x, 0, PlayerController1.player.transform.position.z), Time.deltaTime * 9);
        }
    }

    public void LEFT()
    {
        if(lane == 2)
        { center_left = true; lane = 1; StartCoroutine(fuckyou()); }
        if (lane == 3)
        { right_center = true; lane = 2; StartCoroutine(fuckyou()); }
        
    }

    public void RIGHT()
    {
        if (lane == 1)
        { left_center = true; lane = 2; StartCoroutine(fuckyou()); }
        if (lane == 2)
        { center_right = true; lane = 3; StartCoroutine(fuckyou()); }
    }

    public void JUMP()
    {
        if (!jump)
        {
            jump = true;
        }
    }
    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.2f);
        backJump = true;
        jump = false;
        yield return new WaitForSeconds(0.2f);
        backJump = false;
    }

    IEnumerator fuckyou()
    {
        int hui = lane;
        lane = 2520;
        yield return new WaitForSeconds(0.2f);
        lane = hui;
        center_left = false;
        center_right = false;
        left_center = false;
        right_center = false;
    }
}
