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
public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private ObjectPool<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(
            createFunc: SpawnBullet, 
            actionOnGet: OnBulletRetrieved, 
            actionOnRelease: OnBulletReleased, 
            actionOnDestroy: OnBulletDestroyed, 
            collectionCheck: false, 
            defaultCapacity: 20,
            maxSize: 1000);
    }

    private GameObject SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        return bullet;
    }

    private void OnBulletRetrieved(GameObject bullet)
    {
        if (bullet != null)
        {
            bullet.SetActive(true);
        }
    }

    private void OnBulletReleased(GameObject bullet)
    {
        if (bullet != null)
        {
            bullet.SetActive(false);
            
        }
    }

    private void OnBulletDestroyed(GameObject bullet)
    {
        Destroy(bullet);
    }

    public GameObject GetBullet()
    {
        GameObject bullet = bulletPool.Get();
        return bullet;
    }

    public void StoreBullet(GameObject bullet)
    {
        if (bullet != null)
        {
            bulletPool.Release(bullet);
        }
    }
}
