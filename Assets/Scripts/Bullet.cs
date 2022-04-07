using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 200f;
    public int damage = 50;
    public float explosionRadius = 0f;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        /*- Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
         foreach(Collider collider in colliders)
         {
             if(collider.tag == "Enemy")
             {
                 Damage(collider.transform);
                 Debug.Log("Collided");
             }
         }-*/
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
        if(eG != null)
        {
            eG.TakeDamage(damage);
        }
    }
}
