using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    ///The bullet asset gameobject
    public GameObject bulletPrefab;

    ///The empty gameobject where the bullets will spawn
    public Transform firePoint;
    public float fireForce = 20f, damage;

    public void Fire()
    {
        bulletPrefab.GetComponent<Bullet>().Damage = damage;

        ///creating the bullet object at the firePoint location
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        ///shoots the bullet
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
