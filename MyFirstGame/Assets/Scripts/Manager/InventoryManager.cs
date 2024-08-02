using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager instance { get; private set; }

    private void Awake()
    {
        if (instance!= null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    
    }

    public List<ItemSO> itemList;
    
    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
    }
}
