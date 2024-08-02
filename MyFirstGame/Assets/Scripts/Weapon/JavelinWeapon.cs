using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//标枪
public class JavelinWeapon : Weapon
{
    private GameObject bulletGo;
    public float speed = 10f;
    
    public GameObject bulletPrefab;

    private void Start()
    {
      bulletGo = GameObject.Instantiate(bulletPrefab , transform.position ,transform.rotation);
      bulletGo.transform.parent = transform;
      bulletGo.GetComponent<Collider>().enabled = false;
      if (tag == Tag.INTERACTABLE)
      {
          Destroy(bulletGo.GetComponent<JavelinBullet>());
          bulletGo.tag = Tag.INTERACTABLE;
          PickableObject po = bulletGo.AddComponent<PickableObject>();
          po.ItemSo = GetComponent<PickableObject>().ItemSo;
          Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();
          if (rgd != null)
          {
              rgd.isKinematic = false;
              rgd.constraints = ~RigidbodyConstraints.FreezePositionY;
          }

          bulletGo.GetComponent<Collider>().enabled = true;
          bulletGo.transform.parent = null;
          Debug.Log("开始进入到销毁模式");
          Destroy(this.gameObject);
      }
    }
    

    public override void Attack()
    {
        if (bulletGo != null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            bulletGo.GetComponent<Collider>().enabled = true;
            Destroy(bulletGo , 10);
            bulletGo = null;
            Invoke("SpawnBullet" , 0.5f);
        }else
        {
            if (Time.deltaTime == 1)
            {
                SpawnBullet();
            }
            
        }
    }
    
    private void SpawnBullet()
    {
        bulletGo = GameObject.Instantiate(bulletPrefab , transform.position ,transform.rotation);
        bulletGo.transform.parent = transform;
        bulletGo.GetComponent<Collider>().enabled = false;
        
    }
}
