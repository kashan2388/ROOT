using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   //�����Ǵ� ��

    [SerializeField]
    private float enemySpawnTime = 5f;   //�� ���� �ֱ�

    private MemoryPool enemyMemoryPool;   //�� �����

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
