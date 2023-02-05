using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private int enemyCount;
    //[SerializeField]
    //private GameObject enemyPrefab;   
    //private MemoryPool enemyMemoryPool;   //�� �����

    [SerializeField]
    private GameObject[] enemies;       //�����Ǵ� ��
    private MemoryPool[] enemyMemoryPool = new MemoryPool[3];  //���� ������ �޸� Ǯ

    [Header("Random")]
    [SerializeField]
    private int[] range = new int[3];   //����(Ȯ�� ����)
    [SerializeField]
    private int rand;                   //������ ���� ��(�� ������)

    [Header("Spawn")]
    private Transform SpawnPoint;       //���� ����
    [SerializeField]
    private float enemySpawnTime = 5f;   //�� ���� �ֱ�
    [SerializeField]
    private Transform target;
    private Vector3 direction;

    [SerializeField]
    private AudioClip addClip;
    [SerializeField]
    private AudioClip destroyClip;
    private void Awake()
    {
        SpawnPoint = this.transform;
        for(int i = 0; i < enemyCount; ++i)
        {
            enemyMemoryPool[i] = new MemoryPool(enemies[i], SpawnPoint);
        }
        direction = (target.position - this.transform.position).normalized;

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        
        while(true)
        {
            //GameObject item = enemyMemoryPool.ActivePoolItem();
            //item.transform.position = SpawnPoint.position;
            //item.GetComponent<EnemyMovement>().SetUp(this, target, direction);

            int r = Random.Range(0, 100);
            
            if (r < range[0]) { rand = 0; }
            else if(r < range[1]) { rand = 1; }
            else if(enemyCount == 3 && r < range[2]) { rand = 2; }

            if(addClip != null)
            {
                SoundManager.instance.PlaySound(addClip);
            }

            GameObject item = enemyMemoryPool[rand].ActivePoolItem();
            item.transform.position = SpawnPoint.position;
            item.transform.rotation = SpawnPoint.rotation;

            item.GetComponent<EnemyMovement>().SetUp(this, target, direction);

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    public void DeactiveEnemy(int index, GameObject enemy)
    {
        SoundManager.instance.PlaySound(destroyClip);
        enemyMemoryPool[index].DeactivePoolItem(enemy);
    }
}
