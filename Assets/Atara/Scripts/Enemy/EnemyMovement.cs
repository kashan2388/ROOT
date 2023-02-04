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
    [SerializeField]
    private bool isAttack = false;
    [SerializeField]
    private bool isPlane = false;       //����� �Դϱ�?

    [SerializeField]
    private int id;     //���� ���̵�

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
            //������ TakeDamage�� ȣ���Ѵ� -> �������� ������
            target.gameObject.GetComponentInParent<TreeMovement>().TakeDamage(attackDamage);

            //�ִϸ��̼� ���?
            //���� ���?
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
