using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Source File: HeartsUI
Luka Ivicevic, 101131244
Date Last Modified: November 20, 2020
 Mobile Game Development: Assignment 2
*/

public class HeartsUI : MonoBehaviour
{
    public Sprite[] heartSprites;
    public Image heartsUI;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        heartsUI.sprite = heartSprites[player.currentHealth];
    }

}
