using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 220f;
    public string enemyTag = "Enemy";
    public float fireRate = 3f;
    public float fireCountDown = 0f;

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;


    public AudioSource gunshotAudio;

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    // Update is called once per frame

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy !=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        gunshotAudio.Play();
        GameObject bulletGo1 = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bulletGo2 = (GameObject)Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

        Bullet bullet1 = bulletGo1.GetComponent<Bullet>();
        Bullet bullet2 = bulletGo2.GetComponent<Bullet>();

        if(bullet1 != null)
        {
            bullet1.Seek(target);
        }

        if (bullet2 != null)
        {
            bullet2.Seek(target);
        }
    }
}
