using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO ItemSo;
    
    protected override void Interact()
    {
        Debug.Log("Interact with Pickable " + name);
    }
}
