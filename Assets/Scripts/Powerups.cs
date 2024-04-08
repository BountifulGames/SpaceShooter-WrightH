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
public class Powerups : MonoBehaviour
{
    private GameManager gameManager;
    private int powerType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(GameManager gm, int powerup)
    {
        gameManager = gm;
        powerType = powerup;
    }

    public void ActivatePower(Player player)
    {
        switch(powerType)
        {
            case 0:
                player.Health += 1;
                break;
            case 1:
                player.Speed += 1;
                break;
        }
    }
}
