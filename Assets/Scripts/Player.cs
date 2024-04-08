using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Space Shooter
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 4/8/2024
/////////////////////////////////////////////
public class Player
{
    private int health;
    private int speed;
    private int score;

    public int Health
    {
        get { return health; }
        set { health = Mathf.Max(0, value); }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value, 1, 7); }
    }
    public int Score
    {
        get { return score; }
        set { score = Mathf.Max(0, value); }
    }

    public Player(int startHealth, int startSpeed)
    {
        Speed = startSpeed;
        Health = startHealth;
        Score = 0;
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
