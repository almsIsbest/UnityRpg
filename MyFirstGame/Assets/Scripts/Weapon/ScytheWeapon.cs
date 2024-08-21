using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//镰刀
public class ScytheWeapon : Weapon
{
    private  const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

    public int atkValue = 50;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Attack();
    //     }
    // }


    public override void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ISATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            Debug.Log("镰刀攻击到敌人 攻击力 ： " +  atkValue);
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
        
    }
}
