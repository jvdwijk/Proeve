﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Combat {
    public class SingleTargetAttack : BaseAttack {
        private IDamagable target;

        [SerializeField]
        private AttackDamageCalculator damageCalculator;

        public override void Attack(IDamagable target) {
            SetAttackDamage(damageCalculator.CalculateDamage());
            print(attackDamage);
            base.Attack(target);
        }

        public void Attack() {
            Attack(target);
        }

        public void SetTarget(IDamagable newTarget) {
            target = newTarget;
        }
    }
}