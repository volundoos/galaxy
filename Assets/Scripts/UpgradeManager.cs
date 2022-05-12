using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject RoundTurret;
    public int roundTurretUpgradeTimes = 0;
    public int RoundTurretBulletDmg;
    // Start is called before the first frame update
    void Start()
    {
        RoundTurretBulletDmg = GameObject.Find("Bullet").GetComponent<Bullet>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeTower1()
    {
        if (roundTurretUpgradeTimes <= 3)
        {
            RoundTurretBulletDmg = GameObject.Find("Bullet").GetComponent<Bullet>().damage;
            RoundTurretBulletDmg += 50;
            GameObject.Find("RoundTurret(1)").GetComponent<Turret>().range += 10f;
            roundTurretUpgradeTimes += 1;
        }
    }
}
