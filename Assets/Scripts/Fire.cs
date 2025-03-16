using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private AudioSource fireSound;

    public void FireBullet()
    {
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, Quaternion.Euler(90f, spawnPoint.eulerAngles.y, 0f));

        Rigidbody bulletRb = spawnedBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = spawnPoint.forward * bulletSpeed;
        }

        if (fireSound != null)
        {
            fireSound.Play();
        }

        Destroy(spawnedBullet, 2f);
    }

}
