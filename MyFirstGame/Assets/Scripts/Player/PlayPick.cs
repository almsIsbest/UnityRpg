using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPick : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("player  transform.position : " + transform.position);

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tag.INTERACTABLE)
        {
            PickableObject po = other.gameObject.GetComponent<PickableObject>();

            if (po != null)
            {
                Debug.Log("Pick " + po.ItemSo.name);
                InventoryManager.instance.AddItem(po.ItemSo);
                Destroy(po.gameObject);
            }
        }
    }
}
