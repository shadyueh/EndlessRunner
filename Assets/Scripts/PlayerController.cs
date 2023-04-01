using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int laneSwitchSpeed = 25;
    private CharacterController controller;
    private Animator animator;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; // 0 - left, 1 - middle, 2 - right
    public float laneDistance = 4;
    private Vector3 targetPosition;

    public float jumpForce;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        direction.z = forwardSpeed;
        animator.SetBool("isRunning", true);

        if (controller.isGrounded)
        {
            animator.SetBool("isAirbone",false);
            direction.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        Debug.Log(controller.isGrounded);


        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }

        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane ==0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * laneSwitchSpeed * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }
    
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        animator.SetBool("isAirbone", true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}
