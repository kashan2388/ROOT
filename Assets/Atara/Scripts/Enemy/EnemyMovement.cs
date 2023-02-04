using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Status
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
    private float moveSpeed;
    private float lastAttackTime = 0f;
    [SerializeField]
    private bool isAttack = false;
    [SerializeField]
    private bool isPlane = false;       //비행기 입니까?

    [SerializeField]
    private int id;     //적의 아이디

    public void SetUp(EnemyMemoryPool enemyMemoryPool, Transform target, Vector3 direction)
    {
        this.enemyMemoryPool = enemyMemoryPool;
        this.target = target;
        this.direction = direction;
    }
    private void OnEnable()
    {
        currentHP = maxHP;
        isAttack = false;
    }
    private void Update()
    {
        float dis = (target.position - this.transform.position).magnitude;
        if(dis <= distance)
        {
            isAttack = true;
        }
        else
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
        }
        Attack();
    }

    private void Attack()
    {
        if (isAttack == false)
        {
            return;
        }
        if (Time.time - lastAttackTime >= attackSpeed)
        {
            lastAttackTime = Time.time;

            Debug.Log("Attack");
            //나무의 TakeDamage를 호출한다 -> 데미지를 입힌다
            target.gameObject.GetComponentInParent<TreeMovement>().TakeDamage(attackDamage);

            //애니메이션 재생?
            //사운드 재생?
            if(isPlane)
            {
                enemyMemoryPool.DeactiveEnemy(id, this.gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isPlane && transform.position.z > 10f)
        {
            return;
        }
        currentHP -= damage;

        if(currentHP <= 0)
        {
            enemyMemoryPool.DeactiveEnemy(id, this.gameObject);
        }
    }
}
