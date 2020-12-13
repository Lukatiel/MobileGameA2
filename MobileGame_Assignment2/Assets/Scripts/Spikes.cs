using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: Spikes
Luka Ivicevic, 101131244
Date Last Modified: December 12, 2020
 Mobile Game Development: Assignment 2
*/
public class Spikes : MonoBehaviour
{
    private PlayerController player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDamage(4);
        }
    }
}
