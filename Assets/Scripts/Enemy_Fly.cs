using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fly : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public int health = 1000;
    public int score = 50;
    public int gold = 20;

    void Start()
    {
        target = Waypoints_fly.waypoints_fly[0];

    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            GameObject playerStat = GameObject.Find("PlayerStat");
            ScoreManagement sc = playerStat.GetComponent<ScoreManagement>();
            GoldManager gm = playerStat.GetComponent<GoldManager>();
            sc.getScore(score);
            gm.getGold(gold);
        }
    }

    void Die()
    {
        Destroy(gameObject);
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
        if (wavepointIndex >= Waypoints_fly.waypoints_fly.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints_fly.waypoints_fly[wavepointIndex];
    }
}