using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: GameAssets
Luka Ivicevic, 101131244
Date Last Modified: December 13, 2020
 Mobile Game Development: Assignment 2
*/
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets Instance
    {
        get
        {
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("MusicAssets/GameAssets")) as GameObject).GetComponent<GameAssets>();
            }


            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
