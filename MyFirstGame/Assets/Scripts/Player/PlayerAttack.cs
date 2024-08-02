using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{

     public Weapon weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player  transform.position : " + transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (weapon != null && Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }
    
    public void LoadWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    
    public void UnloadWeapon()
    {
        this.weapon = null;
    }
    
    
}
