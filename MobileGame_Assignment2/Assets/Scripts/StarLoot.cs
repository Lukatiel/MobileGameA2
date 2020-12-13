using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: StarLoot
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/
public class StarLoot : MonoBehaviour
{
    private float star = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Star")
        {
            Score.scoreValue += 10;
            //Play Audio here
            Destroy(collision.gameObject);

            SoundManager.PlaySound(SoundManager.Sound.scorePoints);

            Debug.Log("Collected!");
        }
    }
}
