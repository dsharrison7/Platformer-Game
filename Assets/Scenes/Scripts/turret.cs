
using UnityEngine;

public class TurretRandomFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 20f;
    public float minDelay = 0.5f;
    public float maxDelay = 5f;

    private int shotsFired = 0;
    private float nextFireTime = 0f;

    void Start()
    {
        ScheduleNextShot();
    }

    void Update()
    {
        if (shotsFired >= 5) return;

        if (Time.time >= nextFireTime)
        {
            Fire();
            shotsFired++;
            if (shotsFired < 5) ScheduleNextShot();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.linearVelocity = spawnPoint.forward * bulletSpeed;
        }
        Destroy(bullet, 5f);
    }

    void ScheduleNextShot()
    {
        nextFireTime = Time.time + Random.Range(minDelay, maxDelay);
    }
}
