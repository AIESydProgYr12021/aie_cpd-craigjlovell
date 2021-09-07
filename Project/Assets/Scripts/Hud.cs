using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Inv Inventory;

    void Start()
    {
        Inventory.ItemAdded += InvScript_ItemAdded;
    }

    private void InvScript_ItemAdded(object sender, InvEventArgs e)
    {
        Transform invetoryPanel = transform.Find("InvetoryPanel");
        foreach(Transform slot in invetoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }
}
