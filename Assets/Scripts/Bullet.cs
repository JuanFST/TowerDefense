using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;

    public int damage = 50;

    public float explosionRadius = 0f;
    public GameObject impactEffect;

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
        float distanceThisFrame = speed * Time.deltaTime; ;

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
        Debug.Log("le pegue a algo");
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 4f);

        if (explosionRadius>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        EnemyMovement e = enemy.GetComponent<EnemyMovement>();

        if (e != null)
        {
            e.TakeDamage(damage);

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}