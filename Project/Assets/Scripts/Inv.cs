using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
    private const int slots = 3;
    private List<InvItems> mItems = new List<InvItems>();
    public event EventHandler<InvEventArgs> ItemAdded;

    public void AddItem(InvItems item)
    {
        if(mItems.Count < slots)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InvEventArgs(item));
                }
            }
        }
    }
}
