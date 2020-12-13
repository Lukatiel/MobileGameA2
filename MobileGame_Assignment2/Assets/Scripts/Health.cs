using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Source File: Health
Luka Ivicevic, 101131244
Date Last Modified: December 12, 2020
 Mobile Game Development: Assignment 2
*/
public class Health : MonoBehaviour
{
    public int health;
    public int numHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    void Update()
    {

        
        if(health > numHearts)
        {
            health = numHearts;
        }
        
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            if(i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
