using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseAttack : MonoBehaviour
{
    protected int attackDamage = 0;
    public event Action OnAttack;

    public void Attack(IDamagable target){
        target?.Damage(attackDamage);
        OnAttack?.Invoke();
    }

    public void SetAttackDamage(int damage){
        attackDamage = damage;
    }
}
