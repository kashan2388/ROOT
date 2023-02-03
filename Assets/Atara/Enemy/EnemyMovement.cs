using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //적 메모리 풀
    private EnemyMemoryPool enemyMemoryPool;
    //움직일 방향
    private Vector3 direction;
    //나무의 위치
    private Transform target;
    //나무와 적 간의 거리
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
