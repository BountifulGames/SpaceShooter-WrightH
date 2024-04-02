using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Bullet has exited camera");
        ReturnBullet();
    }

    private void BulletMove()
    {
        Vector3 movement = -gameObject.transform.up * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    private void ReturnBullet()
    {
        bulletManager.StoreBullet(gameObject);
    }

}
