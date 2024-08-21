using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO ItemSo;
    
    protected override void Interact()
    {
        Destroy(this.gameObject);
        Debug.Log("Interact with Pickable " + name);
        InventoryManager.instance.AddItem(ItemSo);
    }
}
