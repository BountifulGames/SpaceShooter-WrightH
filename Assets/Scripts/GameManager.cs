using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//////////////////////////////////////////////
//Assignment/Lab/Project: Space Shooter
//Name: Hunter Wright
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 4/8/2024
/////////////////////////////////////////////
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private List<GameObject> powerupPrefabs;
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    public Player _player;

    private void Awake()
    {
        _player = new Player(3, 3);
    }

    private void Start()
    {
        Time.timeScale = 1f;

        UpdateUI();
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
            int obstacleToSpawn = Random.Range(0, 3);
            Vector3 spawnPos = new Vector3(Random.Range(-9, 10), Random.Range(-3.5f, 5.5f), 0);
            GameObject obstacle = Instantiate(obstaclePrefabs[obstacleToSpawn], spawnPos, Quaternion.identity);
            obstacle.GetComponentInChildren<Obstacle>().Setup(_player, obstacleToSpawn, this);

            int waitTime = Random.Range(2, 7);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator SpawnPowerups()
    {
       yield return new WaitForSeconds(5);
        while(true)
        {
            int powerToSpawn = Random.Range(0, 2);
            Vector3 spawnPos = new Vector3(Random.Range(-9, 10), Random.Range(-3.5f, 5.5f), 0);
            GameObject powerUp = Instantiate(powerupPrefabs[powerToSpawn], spawnPos, Quaternion.identity);
            powerUp.GetComponentInChildren<Powerups>().Setup(this, powerToSpawn);

            yield return new WaitForSeconds(15);
        }
    }

    public void UpdateUI()
    {
        uiText.text = "Health: " + _player.Health +
            "\nSpeed: " + _player.Speed +
            "\nScore: " + _player.Score;
    }

    public void GameOver()
    {
        StopAllCoroutines();
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over \n Score: " + _player.Score;
        Time.timeScale = .25f;

    }

    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("Shooter");
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
