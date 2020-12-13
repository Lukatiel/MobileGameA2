using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Source File: PlayerController
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/

public class PlayerController : MonoBehaviour
{

    public float jumpVelocity;
    public float xInput, yInput;

    private const float MOVE_SPEED = 4f;
    private bool isFacingRight = true;

    [SerializeField] 
    private LayerMask platformLayerMask;
    
    public Animator characterAnim;
    private Health playerHP;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private Vector3 moveDirection;
    Vector3 touchPosition;
    Touch touch;

    private void Awake()
    {
        isFacingRight = true;

        characterAnim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerHP = GetComponent<Health>();
    }

    //Update is called once per frame
    private void Update()
    {
        if(playerHP.health <= 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {

            Debug.Log("Jump!");
            Jump();
            //Vector2 test = Vector2.up * jumpVelocity;
            //Debug.Log(test);
            //Debug.Log(jumpVelocity);

        }

        HandleMovement();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f);
        //Debug.Log(IsGrounded());
        return raycastHit2D.collider != null;
  
    }

    private void FixedUpdate()
    {
        //xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");

        //transform.Translate(xInput * MOVE_SPEED, yInput * MOVE_SPEED, 0);

        //HandleMovement();
        //Flip();

        
       
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        //Need to set the characterAnim.SetBool("isJumping", true); wherever jump function is

        if (Input.GetKey(KeyCode.D))    //For moving right, to add touch option later
        {
            moveX = +1f;
        }
        if (Input.GetKey(KeyCode.A))    //For moving left, to add touch option later
        {
            moveX = -1f;
        }


        Flip(moveX);

        //moveDirection = new Vector3(moveX, moveY);
        characterAnim.SetFloat("Speed", Mathf.Abs(moveX));
        _rigidbody2D.velocity = new Vector2(moveX * MOVE_SPEED, _rigidbody2D.velocity.y);

        SoundManager.PlaySound(SoundManager.Sound.playerWalking);
    }

    void Jump()
    {  
        _rigidbody2D.velocity = Vector2.up * jumpVelocity;
        SoundManager.PlaySound(SoundManager.Sound.playerJump);
    }

    private void Flip(float horizontal)
    {
        
        if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            //Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void TakeDamage(int dmg)
    {
        playerHP.health -= dmg;
        Debug.Log("Took damage");
        Debug.Log(playerHP.health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {

            playerHP.health -= 1;
        }
    }
}
