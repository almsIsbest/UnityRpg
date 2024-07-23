using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    private  const string ANIM_PARM_ISATTACK = "isAttack";

    private Animator anim;

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
            //TODO
            print("Trigger with " + other.name);
        }
        
    }
}
