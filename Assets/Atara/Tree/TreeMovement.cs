using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : Status
{
    //애니메이션
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack(Transform position)
    {
        //죽순 생성
        //죽순의 위치 = position
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
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
