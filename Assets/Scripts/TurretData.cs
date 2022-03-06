using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData
{
    public GameObject turretPrefab;
    public int cost;
    public int costUpdated;
    public TurretType type;
}

public enum TurretType
{
    Turret1,
    Turret2
}
