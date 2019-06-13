using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Stats;

namespace PeppaSquad.Pickups.Effects {
    /// <summary>
    /// Boost type which enhances boost levels
    /// </summary>
    public class StatEnhancingBoost : BoostEffect {
        [SerializeField]
        private BoostStatHandler stats;

        [SerializeField]
        private BoostType statType;

        private void Start() {
            if(!stats)
                stats = BoostStatHandler.Instance;
        }

        /// <summary>
        /// Boosts level
        /// </summary>
        public override void Boost() {
            stats.BoostStat(statType);
        }
    }
}