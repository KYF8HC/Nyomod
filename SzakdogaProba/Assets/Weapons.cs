using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public GameObject bulletPrefab;
    public bool LaserGum = false;
    public bool Pistol = false;
    public GameObject pistol;
    public GameObject laserGun;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LaserGum)
        {
            laserGun.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
                laserGun.SetActive(false);
                LaserGum = false;
            }
        }
        if (Pistol)
        {
            pistol.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                PistolShoot();
                pistol.SetActive(false);
                Pistol = false;
            }
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        yield return new WaitForSeconds(0.5f);

        lineRenderer.enabled = false;
    }

    void PistolShoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
