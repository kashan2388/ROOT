using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Status
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

    //        //������ TakeDamage�� ȣ���Ѵ� -> �������� ������
    //        target.gameObject.GetComponent<TreeMovement>().TakeDamage(attackDamage);

    //        //�ִϸ��̼� ���?
    //        //���� ���?
    //    }
    //}

    private IEnumerator OnAttack()
    {
        target.gameObject.GetComponent<TreeMovement>().TakeDamage(attackDamage);

        //�ִϸ��̼� ���?
        //���� ���?

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
