using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test Console
        //Debug.Log("Hello IT7031C33");

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    
}
