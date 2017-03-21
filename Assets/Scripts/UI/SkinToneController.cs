﻿/******************************************************************************
 * Author: Michael Morris
 * Course: CMPUT401 AR
 * File: SkinToneController.cs
 * 
 * Description: Provides handling of dynamic content for SkinToneController.
 * 
 * ***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinToneController : MonoBehaviour
{
    public DBHandler dbHandler;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;

    protected List<SyncListFinding> colors;

    void Start()
    {

        populate();
 
    }

    public void populate() {

        colors = dbHandler.getColors();

        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach (SyncListFinding color in colors)
        {
            GameObject newColor = Instantiate(ListItemPrefab) as GameObject;
            SkinToneItem controller = newColor.GetComponent<SkinToneItem>();
            controller.Preview.color = color.getColor();
            controller.Name.text = color.name;
            newColor.transform.parent = ContentPanel.transform;
            newColor.transform.localScale = Vector3.one;
            Debug.Log("Added color: Name: " + color.name + " Color: " + color.getColor().ToString());
        }
    }

}
