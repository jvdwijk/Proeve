using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PeppaSquad.Combat
{
    public class BaseAttack : MonoBehaviour
    {
        protected int attackDamage = 1;
        public event Action OnAttack;

        public void Attack(IDamagable target){
            if(target == null) return;
            target.Damage(attackDamage);
            OnAttack?.Invoke();
        }

        public void SetAttackDamage(int damage){
            attackDamage = damage;
        }
    }
}