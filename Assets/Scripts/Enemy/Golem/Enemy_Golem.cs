using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Golem : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        Quaternion q = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, turnSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
