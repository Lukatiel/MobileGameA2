using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Source File: BGloop
Luka Ivicevic, 101131244
Date Last Modified: November 20, 2020
 Mobile Game Development: Assignment 2
*/

public class BGloop : MonoBehaviour
{
    public float choke;
    
    public GameObject[] levels;

    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        foreach(GameObject go in levels)
        {
            loadChildObjects(go);
        }
    }

    void loadChildObjects(GameObject go)
    {
        Debug.Log(go.name);
        float objectWidth = go.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(go) as GameObject;

        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(go.transform);
            c.transform.position = new Vector3(objectWidth * i, go.transform.position.y, go.transform.position.z);
            c.name = go.name + i;
        }

        Destroy(clone);
        Destroy(go.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
