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
    //private bool isAttack = false;

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
            //Debug.Log("Stop");
            //isAttack = true;
            StartCoroutine("OnAttack");
        }
        else
        {
            transform.position += direction * Time.deltaTime * moveSpeed;
            //Vector3 direction = (target.position - this.transform.position).normalized;
        }
    }

    //private void Attack()
    //{
    //    if(isAttack == false)
    //    {
    //        return;
    //    }
    //    if(Time.time - lastAttackTime >= attackSpeed)
    //    {
    //        lastAttackTime = Time.time;

    //        //나무의 TakeDamage를 호출한다 -> 데미지를 입힌다
    //        target.gameObject.GetComponent<TreeMovement>().TakeDamage(attackDamage);

    //        //애니메이션 재생?
    //        //사운드 재생?
    //    }
    //}

    private IEnumerator OnAttack()
    {
        target.gameObject.GetComponent<TreeMovement>().TakeDamage(attackDamage);

        //애니메이션 재생?
        //사운드 재생?

        yield return new WaitForSeconds(attackSpeed);
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
