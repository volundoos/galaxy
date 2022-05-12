using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_fly : MonoBehaviour
{
    public static Transform[] waypoints_fly;

    private void Awake()
    {
        waypoints_fly = new Transform[transform.childCount];
        for (int i = 0; i < waypoints_fly.Length; i++)
        {
            waypoints_fly[i] = transform.GetChild(i);
        }
    }
}
