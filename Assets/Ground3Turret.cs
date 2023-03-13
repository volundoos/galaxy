using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground3Turret : MonoBehaviour
{
    public Transform target;
    public float range = 100f;
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public float fireRate = 3f;
    public Transform firePoint1;
    public Transform firePoint2;
    public float fireCountDown = 0f;
    public GameObject bulletPrefab;

    public AudioSource gunshotAudio;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    public void Shoot()
    {
        gunshotAudio.Play();

        GameObject purpleBullet1 = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject purpleBullet2 = (GameObject)Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        HundredDamageBullet bullet1 = purpleBullet1.GetComponent<HundredDamageBullet>();
        HundredDamageBullet bullet2 = purpleBullet2.GetComponent<HundredDamageBullet>();

        if (bullet1 != null)
        {
            bullet1.Seek(target);
        }
        if (bullet2 != null)
        {
            bullet2.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
