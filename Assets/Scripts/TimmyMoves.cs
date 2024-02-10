using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyMoves : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public bool running;
    public Transform playerTrans;
    private bool isAnimationDone = false;

    void FixedUpdate()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0; // Ensure the movement is only on the horizontal plane
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            desiredMoveDirection += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            desiredMoveDirection -= forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            desiredMoveDirection -= right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            desiredMoveDirection += right;
        }

        // Normalize the movement vector and then apply speed and deltaTime
        desiredMoveDirection = desiredMoveDirection.normalized * w_speed * Time.deltaTime;
        playerRigid.velocity = desiredMoveDirection;

        // Face the direction of forward/backward movement or remain facing the camera's direction when strafing
        if (desiredMoveDirection != Vector3.zero && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            Quaternion toRotation = Quaternion.LookRotation(desiredMoveDirection, Vector3.up);
            playerTrans.rotation = Quaternion.RotateTowards(playerTrans.rotation, toRotation, ro_speed * Time.deltaTime);
        }
        else if (desiredMoveDirection != Vector3.zero && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            // Optional: Adjust if you want specific behavior when strafing, like turning slightly towards the movement direction
            // Currently, it keeps the player facing the direction they were before moving left or right.
        }
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(0); // 0 for the first layer

        // Walking and running logic with animation triggers
        HandleWalkingRunningAnimations();

        // Flip animation logic
        HandleFlipAnimation(stateInfo);
    }

    void HandleWalkingRunningAnimations()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger(walking ? "run" : "walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetTrigger("idle");
            playerAnim.ResetTrigger(walking ? "run" : "walk");
            walking = false;
        }

        if (walking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
            playerAnim.SetTrigger("run");
            running = true;
            playerAnim.ResetTrigger("walk");
        }
        if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
            playerAnim.ResetTrigger("run");
            running = false;
            playerAnim.SetTrigger("walk");
        }
    }

    void HandleFlipAnimation(AnimatorStateInfo stateInfo)
    {
        if (running && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("flip");
            playerAnim.ResetTrigger("run");
        }
        if (stateInfo.IsName("flip") && stateInfo.normalizedTime >= 1)
        {
            if (!isAnimationDone)
            {
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("flip");
                isAnimationDone = true;
            }
        }
        else
        {
            isAnimationDone = false;
        }
    }
}