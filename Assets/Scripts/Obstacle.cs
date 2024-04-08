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
public class Obstacle : MonoBehaviour
{
    private Player _player;
    private int obstacleType;
    private int health;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Bullet has hit " + tag);
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.ReturnBullet();
            }
            health -= 1;

            if (health <= 0)
            {
                Destroy(gameObject.transform.parent.gameObject);
                _player.Score++;
            }
            gameManager.UpdateUI();
        }
    }

    public void Setup(Player player, int obstacle, GameManager gm)
    {
        _player = player;
        obstacleType = obstacle;
        gameManager = gm;

        switch (obstacleType)
        {
            case 0: //Spike
                health = 1;
                break;
            case 1: //Ship
                health = 2;
                break;
            case 2: //Asteroid
                health = 3;
                break;
        }
    }
}
