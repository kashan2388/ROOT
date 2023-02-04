using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : Status
{
    [SerializeField]
    private UIManager uIManager;
    [SerializeField]
    private GameObject YouDie;

    //애니메이션
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
            //게임 재시작

        }
    }

    //트리 성장
    public void GrowUpTree()
    {
        //애니메이션
        //오브젝트 교체
    }
}
