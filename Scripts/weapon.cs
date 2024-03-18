using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public static weapon instance;
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public float projectileSpeed;

    private void Start()
    {
        if (instance == null)
        {
               instance = this;
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(shotPoint.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
