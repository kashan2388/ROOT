using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : Status
{
    [SerializeField]
    private UIManager uIManager;
    [SerializeField]
    private GameObject YouDie;

    //�ִϸ��̼�
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        uIManager.SetHP(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        uIManager.SetHP(currentHP, maxHP);
        if (currentHP <= 0)
        {
            YouDie.SetActive(true);
            Time.timeScale = 0;
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
