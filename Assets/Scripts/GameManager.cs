using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private List<GameObject> powerupPrefabs;
    public Player _player;

    private void Awake()
    {
        _player = new Player(10, 3);
    }

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnPowerups());

    }

    private void Update()
    {
        
    }

    private IEnumerator SpawnObstacle()
    {
        while(true)
        {
            int obstacleToSpawn = Random.Range(0, 1);
            Vector3 spawnPos = new Vector3(Random.Range(-10, 11), Random.Range(-4.5f, 6.5f), 0);
            Instantiate(obstaclePrefabs[obstacleToSpawn], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator SpawnPowerups()
    {
        while(true)
        {
            int powerToSpawn = Random.Range(0, 2);
            Vector3 spawnPos = new Vector3(Random.Range(-10, 11), Random.Range(-4.5f, 6.5f), 0);
            GameObject powerUp = Instantiate(powerupPrefabs[powerToSpawn], spawnPos, Quaternion.identity);
            powerUp.GetComponent<Powerups>().Setup(this);
        }
    }
}
