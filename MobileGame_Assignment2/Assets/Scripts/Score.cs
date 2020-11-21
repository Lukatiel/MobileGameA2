using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Source File: Score
Luka Ivicevic, 101131244
Date Last Modified: November 20, 2020
 Mobile Game Development: Assignment 2
*/

public class Score : MonoBehaviour
{
    Text score;
    
    public static int scoreValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}
