using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform golem;
    public Transform minion;
    public Transform fly;

    public Transform golemSpawnPoint;
    public Transform minionSpawnPoint;
    public Transform flySpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5.5f;

    public GameObject gameOverUI;

    private int waveIndex = 0;
    void Update()
    {
        if (EnemiesAlive <= 0)
        {
            if (countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
        }
        countdown -= Time.deltaTime;

        if(waveIndex > 20)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
  
        for (int i = 0; i < waveIndex; i++)
        {
            
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(golem, golemSpawnPoint.position, golemSpawnPoint.rotation);
        Instantiate(minion, minionSpawnPoint.position, minionSpawnPoint.rotation);
        Instantiate(fly, flySpawnPoint.position, flySpawnPoint.rotation);
        EnemiesAlive += 3;
    }
}
