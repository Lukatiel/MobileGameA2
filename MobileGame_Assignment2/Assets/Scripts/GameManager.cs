using UnityEngine;

/*
Source File: GameManager
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.Initialize();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
