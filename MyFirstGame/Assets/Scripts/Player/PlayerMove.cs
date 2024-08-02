using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    
    private NavMeshAgent playerAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        Debug.Log("player  transform.position : " + transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray,out hit);
            if (isCollide)
            {
                /**
                 * 检查是移动还是可交互的物体
                 根据 tag 判断
                 */
                if (hit.collider.tag == "Ground") 
                {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }else if (hit.collider.tag == "Interactable")
                { 
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }
            }
        }
    }
}
