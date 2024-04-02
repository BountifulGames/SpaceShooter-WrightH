using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int health;
    private int speed;

    public int Health
    {
        get { return health; }
        set { health = Mathf.Max(0, value); }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 10); }
    }

    public Player(int startHealth, int startSpeed)
    {
        Speed = startSpeed;
        Health = startHealth;
    }
}
