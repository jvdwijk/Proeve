using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Stats;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Combat {
    public class AttackDamageCalculator : MonoBehaviour {

        [SerializeField]
        private PlayerStatsHandler playerStats;

        [SerializeField]
        private BoostStatHandler boostStats;

        [SerializeField]
        private int baseDamage = 5;

        /// <summary>
        /// Calculates the damage of an attack using the playerstats and the currently activated boosts.
        /// </summary>
        /// <returns>attack damage</returns>
        public virtual int CalculateDamage() {
            var playerDamageLevel = playerStats.GetOrCreateStat(PlayerStatType.Damage);
            var damageBoostLevel = boostStats?.GetOrCreateStat(BoostType.Damage);

            int attackDamage = baseDamage + Mathf.RoundToInt(2.5f * playerDamageLevel.Value) + Mathf.RoundToInt(3.5f * damageBoostLevel.Value);

            return attackDamage;

        }

    }
}