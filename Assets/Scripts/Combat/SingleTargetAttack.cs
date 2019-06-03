using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Combat {
    public class SingleTargetAttack : BaseAttack {
        private IDamagable target;

        [SerializeField]
        protected AttackDamageCalculator damageCalculator;

        protected override int CalculateAttackDamage() {
            return damageCalculator.CalculateDamage();
        }

        public void Attack() {
            Attack(target);
        }

        public void SetTarget(IDamagable newTarget) {
            target = newTarget;
        }
    }
}