using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   //�����Ǵ� ��

    [SerializeField]
    private float enemySpawnTime = 1;   //�� ���� �ֱ�

    private MemoryPool enemyMemoryPool;   //�� �����

    private int numberOfEnemiesSpawnedAtOnce = 1;  //���ÿ� �����Ǵ� ���� ��

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
