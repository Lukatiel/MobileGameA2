using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: SnailAI
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/
public class SnailAI : MonoBehaviour
{
    public float speed;
    public bool isFacingLeft;

    public Rigidbody2D _rigidbody2D;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.collider.CompareTag("Player") && collision.collider.CompareTag("Platforms"))
        {
            isFacingLeft = !isFacingLeft;
        }

        if(isFacingLeft)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }

    private void Flip()
    {

        isFacingLeft = !isFacingLeft;

        //Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
