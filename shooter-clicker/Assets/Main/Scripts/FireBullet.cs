using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bullets;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float shotSpeed;
    [SerializeField]
    private GameObject muzzleLocation;
    private Animator animator;
    private bool isShooting = false;
    private GameObject firePoint;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(ShotTimer());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isShooting = true;
            animator.SetBool("IsFiring", true);
        }
        else
        {
            animator.SetBool("IsFiring", false);
            isShooting = false;
        }
    }

    private IEnumerator ShotTimer()
    {
        while (true)
        {
            while (isShooting)
            {
                Shoot();
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        var bullet = bullets.FirstOrDefault(b => !b.activeSelf);

        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().speed = shotSpeed;
            bullet.transform.position = muzzleLocation.transform.position;
            bullet.transform.rotation = muzzleLocation.transform.rotation;
        }
    }
}
