using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 交互物体的基类
public class InteractableObject : MonoBehaviour
{
    
    private NavMeshAgent playerAgent;
    private bool hasInteracted;
    
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        hasInteracted = false;
        // Interact();
    }
    
    private void Update()
    {
        if (playerAgent != null && !hasInteracted  && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    
    
    
    protected virtual void Interact()
    {
        Debug.Log("Interact with " + name);
    }
    

}
