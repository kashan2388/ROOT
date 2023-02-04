using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMovement : Status
{
    //�ִϸ��̼� �����
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //��ȭ���� �����ϸ� Ȱ��ȭ�ȴ�
    private void OnEnable()
    {
        //���� �ӵ�
        attackSpeed = 5f;
        //���� ���� -> �ڷ�ƾ?
        StartCoroutine("OnAttack");
    }

    //����
    private IEnumerator OnAttack()
    {
        //�� ������Ʈ ���� -> ������
        yield return new WaitForSeconds(attackSpeed);
    }

    public void StopAttack()
    {
        StopCoroutine("OnAttack");
    }

    //���� ���Դٰ� �� ������, �ٽ� ���� -> ��ġ�� ����? �Ӹ���

}
