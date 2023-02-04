using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMovement : Status
{
    //애니메이션 제어용
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //강화에서 구매하면 활성화된다
    private void OnEnable()
    {
        //공격 속도
        attackSpeed = 5f;
        //공격 시작 -> 코루틴?
        StartCoroutine("OnAttack");
    }

    //공격
    private IEnumerator OnAttack()
    {
        //돌 오브젝트 생성 -> 던진다
        yield return new WaitForSeconds(attackSpeed);
    }

    public void StopAttack()
    {
        StopCoroutine("OnAttack");
    }

    //빼꼼 나왔다가 돌 던지고, 다시 들어가고 -> 위치값 조정? 머리만

}
