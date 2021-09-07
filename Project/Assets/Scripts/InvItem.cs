using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface InvItems
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
}

public class InvEventArgs : EventArgs
{
    public InvEventArgs(InvItems item)
    {
        Item = item;
    }
    public InvItems Item;
}
