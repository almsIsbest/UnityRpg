using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//标枪子弹
public class JavelinBullet : MonoBehaviour
{
    public int atkValue = 30;
    private Rigidbody rgd;
    private Collider col;
    
    
    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag  + "   , "  + other.gameObject.name);
        if (other.gameObject.tag == Tag.PLAYER)
        {
            return;
        }
        
        rgd.velocity = Vector3.zero;
        rgd.isKinematic = true;
        col.enabled = false;

        transform.parent = other.gameObject.transform;
        
        Destroy(this.gameObject , 3f);
        
        if(other.gameObject.tag == Tag.ENEMY)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
