using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, InvItems
{
    public Enery_Chase enemy = null;
    public PlayerController player;
    public string Name
    {
        get
        {
            return "Battery";
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
        player.items += 1;
        enemy.myAgent.speed += 0.5f;
    }
}
