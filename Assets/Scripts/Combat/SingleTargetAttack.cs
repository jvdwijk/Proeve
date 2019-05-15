using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Combat {
    public class SingleTargetAttack : BaseAttack {
        private IDamagable target;

        public void Attack() {
            Attack(target);
        }

        public void SetTarget(IDamagable newTarget) {
            target = newTarget;
        }
    }
}