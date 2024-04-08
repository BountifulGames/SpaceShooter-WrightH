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
public class Bullet : MonoBehaviour
{
    private float speed = 12f;
    private BulletManager bulletManager;

    // Start is called before the first frame update

    private void Awake()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }
    void Start()
    {
    }

    void Update()
    {
        BulletMove();
    }

    void OnBecameInvisible()
    {
        ReturnBullet();
    }

    private void BulletMove()
    {
        Vector3 movement = -gameObject.transform.up * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    public void ReturnBullet()
    {
        bulletManager.StoreBullet(gameObject);
    }

}
