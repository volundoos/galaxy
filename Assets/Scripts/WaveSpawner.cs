using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform golem;
    public Transform minion;
    public Transform fly;

    public Transform golemSpawnPoint;
    public Transform minionSpawnPoint;
    public Transform flySpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5.5f;


    private int waveIndex = 0;
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        Debug.Log("wave incomming");
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(golem, golemSpawnPoint.position, golemSpawnPoint.rotation);
        Instantiate(minion, minionSpawnPoint.position, minionSpawnPoint.rotation);
        Instantiate(fly, flySpawnPoint.position, flySpawnPoint.rotation);
    }
}
