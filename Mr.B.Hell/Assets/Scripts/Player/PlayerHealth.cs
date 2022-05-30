using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public int health { get; private set; }

    public PlayerHealth(PlayerData data)
    {
        health = data.health;
    }

    public bool MinusHeath(int amount)
    {
        health -= amount;
        Debug.Log("minus" + health);
        return health <= 0;
    }
}
