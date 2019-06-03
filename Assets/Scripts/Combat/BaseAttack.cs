using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Combat {
    public class BaseAttack : MonoBehaviour {
        protected int attackDamage = 1;
        public event Action OnAttack;

        /// <summary>
        /// Damages the target
        /// </summary>
        /// <param name="target">The entity you want</param>
        public virtual void Attack(IDamagable target) {
            if (target == null) return;
            target.Damage(CalculateAttackDamage());
            OnAttack?.Invoke();
        }

        protected virtual int CalculateAttackDamage() {
            return attackDamage;
        }

        /// <summary>
        /// Sets the attack damage :)
        /// </summary>
        /// <param name="damage">the new attack damage</param>
        public void SetAttackDamage(int damage) {
            attackDamage = damage;
        }
    }
}