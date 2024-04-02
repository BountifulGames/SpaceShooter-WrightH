using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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
}
