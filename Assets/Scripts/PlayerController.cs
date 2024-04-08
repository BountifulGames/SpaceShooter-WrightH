using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//////////////////////////////////////////////
//Assignment/Lab/Project: Space Shooter
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 4/8/2024
/////////////////////////////////////////////
public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 100f;
    private Player player;

    [SerializeField] private BulletManager bulletManager;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        player = gameManager._player;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Bounds();

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(player.Speed);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalRotation = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontalRotation * rotationSpeed * Time.deltaTime);

        Vector3 movement = new Vector3(0, 0, verticalInput) * player.Speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    private void Bounds()
    {
        if (gameObject.transform.position.x < -11)
        {
            Vector3 temp = new Vector3(11, transform.position.y, transform.position.z);
            transform.position = temp;
        }
        if (gameObject.transform.position.x > 11)
        {
            Vector3 temp = new Vector3(-11, transform.position.y, transform.position.z);
            transform.position = temp;
        }

        if (gameObject.transform.position.y < -5.5)
        {
            Vector3 temp = new Vector3(transform.position.x, 7.5f, transform.position.z);
            transform.position = temp;
        }
        if (gameObject.transform.position.y > 7.5)
        {
            Vector3 temp = new Vector3(transform.position.x, -5.5f, transform.position.z);
            transform.position = temp;
        }
    }

    private void Shoot()
    {
        GameObject bullet = bulletManager.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Powerups powerUp = other.gameObject.GetComponent<Powerups>();
            powerUp.ActivatePower(player);
            Destroy(other.gameObject.transform.parent.gameObject);

            Debug.Log("Health: " + player.Health);
            Debug.Log("Speed: " + player.Speed);
            Debug.Log("Score: " + player.Score);
        }

        if (other.CompareTag("Enemy"))
        {
            player.TakeDamage();
            Destroy(other.gameObject.transform.parent.gameObject);
        }

        gameManager.UpdateUI();

        if (player.Health <= 0)
        {
            gameManager.GameOver();
        }
    }
}
