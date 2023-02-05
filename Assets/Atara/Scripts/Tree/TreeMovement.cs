using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : Status
{
    [SerializeField]
    private UIManager uIManager;
    [SerializeField]
    private GameObject YouDie;

    [SerializeField]
    private AudioClip hitClip;
    [SerializeField]
    private AudioClip deathClip;

    //�ִϸ��̼�
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        uIManager.SetHP(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySound(hitClip);
        currentHP -= damage;
        uIManager.SetHP(currentHP, maxHP);
        if (currentHP <= 0)
        {
            SoundManager.instance.PlaySound(deathClip);
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
