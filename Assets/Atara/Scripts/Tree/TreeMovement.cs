using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : Status
{
    //�ִϸ��̼�
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack(Transform position)
    {
        //�׼� ����
        //�׼��� ��ġ = position
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            //���� �����
        }
    }

    //Ʈ�� ����
    public void GrowUpTree()
    {
        //�ִϸ��̼�
        //������Ʈ ��ü
    }
}
