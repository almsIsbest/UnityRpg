using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    private GameObject bulletGo;
    public float speed = 10f;
    
    public GameObject bulletPrefab;

    private void Start()
    {
      bulletGo = GameObject.Instantiate(bulletPrefab , transform.position ,transform.rotation);
      bulletGo.transform.parent = transform;
    }


    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            bulletGo = null;
            Invoke("SpawnBullet" , 0.5f);
        }
    }
    
    private void SpawnBullet()
    {
        bulletGo = GameObject.Instantiate(bulletPrefab , transform.position ,transform.rotation);
        bulletGo.transform.parent = transform;
    }
}
