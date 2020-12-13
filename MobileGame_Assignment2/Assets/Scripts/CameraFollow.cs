using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: CameraFollow
Luka Ivicevic, 101131244
Date Last Modified: December 12, 2020
 Mobile Game Development: Assignment 2
*/
public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.followTransform.position.z);
    }
}
