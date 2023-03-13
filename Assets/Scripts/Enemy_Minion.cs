using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Minion : MonoBehaviour
{
    public float speed = 50f;
    public float turnSpeed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public int health = 200;
    public int score = 20;
    public int gold = 10;

    public LivesOfMinion livesOfMinion;
    private void Start()
    {
        target = Waypoints_minion.waypoints_minion[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        livesOfMinion.SetLivesOfMinion(health);

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject playerStat = GameObject.Find("PlayerStat");
        ScoreManagement sc = playerStat.GetComponent<ScoreManagement>();
        GoldManager gm = playerStat.GetComponent<GoldManager>();
        sc.getScore(score);
        gm.getGold(gold);
        WaveSpawner.EnemiesAlive--;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        Quaternion q = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints_minion.waypoints_minion.Length - 1)
        {
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
            return;
        }

        wavepointIndex++;
        target = Waypoints_minion.waypoints_minion[wavepointIndex];
    }
}
