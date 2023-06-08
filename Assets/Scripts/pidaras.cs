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
        Direction dir = swipeControls.GetCurrentSwipe();

        MovePlayer(dir);
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
        if (!jump && !backJump)
        {
            jump = true;
        }
    }
    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.2f);
        jump = false;
        backJump = true;
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

    void returnBoostersAlpha() 
    {
        HiderBoosters.timeLastUseBooster = 15;
        HiderBoosters.boostersGameObject.SetActive(true);
        StartCoroutine(HiderBoosters.ShowAllBoosters());
    } 
}
