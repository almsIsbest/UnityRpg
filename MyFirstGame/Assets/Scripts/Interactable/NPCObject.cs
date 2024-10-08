using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{

    [SerializeField] private string name;
    [SerializeField] private string[] content;
    
    
    protected override void Interact()
    {
        Debug.Log("进入NPC 对话");
        DialogueUI.instance.show(name, content);
    }
}
