using UnityEngine;

public class TurretLook : MonoBehaviour
{
    [Header("General")]
    public float range = 12f;
    
    [Header("Use Bullets")]
    public float fireRate = 1f;
    private float fireCountdown;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserParticles;
    public Light laserGlowLight;

    [Header("Setup Fields")]
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";
    public LayerMask layerMask;
    

    
    private Transform target;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        fireCountdown -= Time.deltaTime;

        if (target == null)
        {
            if (useLaser)
            {
                lineRenderer.enabled = false;
                laserParticles.Stop();
                laserGlowLight.enabled = false;
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserParticles.Play();
            laserGlowLight.enabled = true;
        }
        

        lineRenderer.SetPosition(0, bulletSpawn.position);
        lineRenderer.SetPosition(1, target.position);

        laserParticles.transform.position = target.position;
        laserParticles.transform.LookAt(bulletSpawn);
        laserParticles.transform.position += laserParticles.transform.forward * 1f;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if(bulletScript == null)
        {
            return;
        }

        bulletScript.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if(dist >= shortestDist)
            {
                continue;
            }

            shortestDist = dist;
            nearestEnemy = enemy;
        }

        if(nearestEnemy == null)
        {
            target = null;
            return;
        }

        if(shortestDist > range)
        {
            target = null;
            return;
        }

        target = nearestEnemy.transform;
    }
}
