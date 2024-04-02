using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private ObjectPool<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(createFunc: SpawnBullet, actionOnGet: SendBullet, actionOnRelease: StopBullet, actionOnDestroy: DestroyBullet, collectionCheck: false, defaultCapacity: 10, maxSize: 15);
    }

}
