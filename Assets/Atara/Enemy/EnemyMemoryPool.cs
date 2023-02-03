using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   //积己登绰 利

    [SerializeField]
    private float enemySpawnTime = 5f;   //利 积己 林扁

    private MemoryPool enemyMemoryPool;   //利 力绢侩

    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private Transform target;
    private Vector3 direction;

    private void Awake()
    {
        enemyMemoryPool = new MemoryPool(enemyPrefab);
        direction = (target.position - this.transform.position).normalized;

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject item = enemyMemoryPool.ActivePoolItem();
            item.transform.position = SpawnPoint.position;

            item.GetComponent<EnemyMovement>().SetUp(this, target, direction);

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    public void DeactiveEnemy(GameObject enemy)
    {
        enemyMemoryPool.DeactivePoolItem(enemy);
    }
}
