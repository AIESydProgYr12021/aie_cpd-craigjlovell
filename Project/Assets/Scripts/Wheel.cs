using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour, InvItems
{
    public Enery_Chase enemy = null;
    public PlayerController player;
    public string Name
    {
        get
        {
            return "Wheel";
        }
    }
    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
        enemy.myAgent.speed += 0.5f;
        player.items += 1;
    }
}
