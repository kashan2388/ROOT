using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public float attackSpeed;
    public int attackDamage;

    public void UpDamage(int damage)
    {
        attackDamage += damage;
    }
}
