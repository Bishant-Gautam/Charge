using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    
    private float leftRightMove;
    bool isMoving;
    bool faceRight = true;

    // Update is called once per frame
    void Update()
    {
        Movement();

    }
    //This method is used to move the charcter left and right also play the animation
    void Movement()
    {
        leftRightMove = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(leftRightMove * movementSpeed, rigidBody.velocity.y);
        if (leftRightMove == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        animator.SetBool("running", isMoving);

        if( leftRightMove > 0 && !faceRight)
        {
            Flip();

        }
        else if(leftRightMove < 0 && faceRight)
        {
            Flip();

        }

    }
    //This method is made to flip the charcter left and right when pressing a and d respectively.
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        faceRight = !faceRight;
    }
}
