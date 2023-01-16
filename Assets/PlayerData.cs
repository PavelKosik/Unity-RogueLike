using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float numberOfGold;
    public float health;
    public PlayerData(Player player)
    {
        numberOfGold = player.numberOfGold;
        health = player.health;
    }
  
}
