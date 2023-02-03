using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   //积己登绰 利

    [SerializeField]
    private float enemySpawnTime = 1;   //利 积己 林扁

    private MemoryPool enemyMemoryPool;   //利 力绢侩

    private int numberOfEnemiesSpawnedAtOnce = 1;  //悼矫俊 积己登绰 利狼 荐

    [SerializeField]
    private Transform SpawnPoint;

    private void Awake()
    {
        enemyMemoryPool = new MemoryPool(enemyPrefab);

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject item = enemyMemoryPool.ActivePoolItem();
            item.transform.position = SpawnPoint.position;

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }
}
