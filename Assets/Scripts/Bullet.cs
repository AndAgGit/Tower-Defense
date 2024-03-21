using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
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
        Destroy(effect, 2);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
