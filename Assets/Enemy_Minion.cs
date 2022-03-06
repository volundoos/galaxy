using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Minion : MonoBehaviour
{
    public float speed = 50f;
    public float turnSpeed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints_minion.waypoints_minion[0];

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
            return;
        }

        wavepointIndex++;
        target = Waypoints_minion.waypoints_minion[wavepointIndex];
    }
}
