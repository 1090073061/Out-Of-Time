using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController_Player : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isFallingHash;

    Rigidbody rb;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        rb = transform.root.GetComponent<Rigidbody>();

        Player = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {
        //  MOVEMENT 

        //Boolean parameters for movement
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isFalling = animator.GetBool(isFallingHash);
        bool leftRight = Input.GetKey("a") || Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        //Check the parameters for movement and play animation
        if(!isWalking && leftRight)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !leftRight)
        {
            animator.SetBool("isWalking", false);
        }

        if (!isRunning && (leftRight && runPressed))
        {
            animator.SetBool("isRunning", true);
        }

        if (isRunning && (!leftRight || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }
     
        if(!isFalling && (rb.velocity.y != 0))
        {
            animator.SetBool("isFalling", true);
        }

        if(rb.velocity.y == 0)
        {
            animator.SetBool("isFalling", false);
        }

        //  COMBAT  

        //Trigger attack if button pressed

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetTrigger("Attack1");
            animator.ResetTrigger("Attack2");
        }

        if (Input.GetKey(KeyCode.G))
        {
            animator.SetTrigger("Attack2");
            animator.ResetTrigger("Attack1");
        }

    }
}
