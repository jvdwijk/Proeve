using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Combat {
    public class BaseAttack : MonoBehaviour {
        protected int attackDamage = 1;
        public event Action OnAttack;

        public virtual void Attack(IDamagable target) {
            if (target == null) return;
            target.Damage(CalculateAttackDamage());
            OnAttack?.Invoke();
        }

        protected virtual int CalculateAttackDamage() {
            return attackDamage;
        }

        public void SetAttackDamage(int damage) {
            attackDamage = damage;
        }
    }
}