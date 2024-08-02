using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    
    //1.移动
    //2.休息
    //3.攻击
    
    public enum EnemyState
    {
        NormalState,
        FightState,
        MovingState,
        RestingStat
    }

    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingStat;
    private NavMeshAgent enemyAgent;
    public int HP = 100;

    public float restTime = 4;
    private float resetTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        if (state == EnemyState.NormalState)
        {
            if (childState == EnemyState.RestingStat)
            {
                resetTimer += Time.deltaTime;
                if (resetTimer > restTime)
                {
                    Vector3 randomPosition = FindRandomPostion();
                    enemyAgent.SetDestination(randomPosition);
                    childState = EnemyState.MovingState;
                }
                
            }else if (childState == EnemyState.MovingState)
            {
                if (enemyAgent.remainingDistance <= 0)
                {
                    resetTimer = 0;
                    childState = EnemyState.RestingStat;
                }
            }
        }
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(30);
        // }
        
    }




    Vector3 FindRandomPostion()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return transform.position + randomDir.normalized * Random.Range(2, 5);
    }
    
    public void TakeDamage(int damage)
    {
        HP-=damage;
        if (HP <= 0)
        {
            GetComponent<Collider>().enabled = false;
            int count = Random.Range(0, 4);
            // count = 4;
            for (int i = 0; i < count; i++)
            {
                SpawnPickableItem();
            }
            Destroy(this.gameObject);
        }
    }


    private void SpawnPickableItem()
    {
        ItemSO item = ItemDBManager.instance.GetRandomItem();
        print(transform.position); 
        GameObject go =GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.INTERACTABLE;
        Animator anim = go.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }

        PickableObject po =  go.AddComponent<PickableObject>();
        po.ItemSo = item;
        Collider collider = go.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }

        Rigidbody rgd = go.GetComponent<Rigidbody>();
        if (rgd != null)
        {
            rgd.isKinematic = false;
            rgd.useGravity = true;
        }
    }
    
    
}
