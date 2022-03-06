using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_minion : MonoBehaviour
{
    public static Transform[] waypoints_minion;

    private void Awake()
    {
        waypoints_minion = new Transform[transform.childCount];
        for (int i = 0; i < waypoints_minion.Length; i++)
        {
            waypoints_minion[i] = transform.GetChild(i);
        }
    }
}
