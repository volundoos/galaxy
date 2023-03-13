using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunFifDmgBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 200f;
    public int damage = 150;
    public int damageToGolem = 300;
    public int damageToFly = 120;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        Damage(target);
        Debug.Log("Collided");
    }

    void Damage(Transform enemy)
    {
        Enemy_Minion e = enemy.GetComponent<Enemy_Minion>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }

        Enemy_Golem eG = enemy.GetComponent<Enemy_Golem>();
        if (eG != null)
        {
            eG.TakeDamage(damageToGolem);
        }

        Enemy_Fly eF = enemy.GetComponent<Enemy_Fly>();
        if (eF != null)
        {
            eF.TakeDamage(damageToFly);
        }
    }
}
