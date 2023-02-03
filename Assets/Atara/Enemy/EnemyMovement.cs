using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //�� �޸� Ǯ
    private EnemyMemoryPool enemyMemoryPool;
    //������ ����
    private Vector3 direction;
    //������ ��ġ
    private Transform target;
    //������ �� ���� �Ÿ�
    [SerializeField]
    private float distance;

    [Header("Status")]
    [SerializeField]
    private int maxHP = 10;
    private int currentHP;
    [SerializeField]
    private float moveSpeed = 1f;


    public void SetUp(EnemyMemoryPool enemyMemoryPool, Transform target, Vector3 direction)
    {
        this.enemyMemoryPool = enemyMemoryPool;
        this.target = target;
        this.direction = direction;

        currentHP = maxHP;
    }
    private void Update()
    {
        float dis = (target.position - this.transform.position).magnitude;
        if(dis <= distance)
        {
            Debug.Log("Stop");
        }
        else
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
            //Vector3 direction = (target.position - this.transform.position).normalized;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP <= 0)
        {
            enemyMemoryPool.DeactiveEnemy(this.gameObject);
        }
    }
}
