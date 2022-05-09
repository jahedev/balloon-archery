using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrow;
    public float fireRate = .5f;
    public float nextFire = 0f;

    AudioSource audioSource;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
    }
}
