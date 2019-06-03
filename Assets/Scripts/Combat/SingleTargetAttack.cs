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

        /// <summary>
        /// attacks the target
        /// </summary>
        public void Attack() {
            Attack(target);
        }
        
        /// <summary>
        /// Changes the target
        /// </summary>
        /// <param name="newTarget"></param>
        public void SetTarget(IDamagable newTarget) {
            target = newTarget;
        }
    }
}