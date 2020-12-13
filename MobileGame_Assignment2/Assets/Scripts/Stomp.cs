using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: Stomp
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/
public class Stomp : MonoBehaviour
{
    float force;
    bool stomped = false;

    public BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            playerRB.AddForce(Vector2.up * force);
            stomped = true;
            boxCollider2D = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            //boxCollider2D.enabled = false;
            Debug.Log(stomped);
        }
        if(stomped == true)
        {
            Score.scoreValue += 20;
            //Play Audio here
            Destroy(transform.parent.gameObject);
        }

    }

   
}
