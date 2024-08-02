using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;

    public float spwanTime;
    
    private float spawnTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spwanTime)
        {
            Debug.Log("spawnTimer : " + spawnTimer);
            spawnTimer = 0;
            SpawnEnemy();
        }
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    
    
}
