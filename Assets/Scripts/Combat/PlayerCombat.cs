using System;
using UnityEngine;
using PeppaSquad.Enemies;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Combat {
    public class PlayerCombat : MonoBehaviour {
        private Enemy currentEnemy;

        [SerializeField]
        private PlayerStatsHandler stats;

        [SerializeField]
        private SingleTargetAttack[] attacks;

        [SerializeField]
        private int baseAttack = 5;

        public Enemy CurrentEnemy { get { return currentEnemy; } set { currentEnemy = value; OnTargetChange?.Invoke(value); } }

        public event Action<IDamagable> OnTargetChange;

        private void Awake() {
            foreach (var attack in attacks) {
                attack.SetAttackDamage(baseAttack);
                attack.SetTarget(currentEnemy);
                OnTargetChange += attack.SetTarget;
            }
        }
    }
}