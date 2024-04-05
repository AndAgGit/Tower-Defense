using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 5;
    public GameObject bulletHitEffect;

    private Transform target;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    // Update is called once per frame
    void Update()
    {
       if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(target);

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }

        transform.Translate(transform.forward * distanceThisFrame, Space.World);
    }

    private void Hit()
    {
        GameObject effect = Instantiate(bulletHitEffect, transform.position, transform.rotation);
        Destroy(effect, 5);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null){
            e.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
}
