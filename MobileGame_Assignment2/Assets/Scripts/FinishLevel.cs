using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Source File: FinishLevel
Luka Ivicevic, 101131244
Date Last Modified: December 12, 2020
 Mobile Game Development: Assignment 2
*/
public class FinishLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Flag")
        {
            Score.scoreValue += 50;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Play Audio here

            Debug.Log("Collected!");
        }
    }
}
