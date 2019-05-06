using System;
using UnityEngine;

using PeppaSquad.Enemies;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        private Enemy currentEnemy;
        public Enemy CurrentEnemy{ get{ return currentEnemy; } set{ currentEnemy = value; OnTargetChange?.Invoke(value); }}
        
        [SerializeField]
        private PlayerStatsHandler stats;

        [SerializeField]
        private SingleTargetAttack[] attacks;

        public event Action<IDamagable> OnTargetChange;

        private void Awake(){
            foreach (var attack in attacks)
            {
                attack.SetAttackDamage(5);
                OnTargetChange += attack.SetTarget;
            }
        }
    }    
}
