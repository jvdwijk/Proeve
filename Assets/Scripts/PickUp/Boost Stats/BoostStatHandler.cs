using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;

namespace PeppaSquad.Pickups.Stats {
    /// <summary>
    /// Handles pickups boost levels.
    /// </summary>
    /// <typeparam name="BoostType"></typeparam>
    public class BoostStatHandler : ResettabeStatsHandler<BoostType> {

        [SerializeField]
        private float boostTime;

        private static BoostStatHandler instance;
        public static BoostStatHandler Instance => instance;

        /// <summary>
        /// Called before first frame, sets singleton
        /// </summary>
        private void Awake() {
            if (instance != null) {
                Destroy(this);
                return;
            }

            instance = this;
        }

        /// <summary>
        /// Resets all pickup stats to 0.
        /// </summary>
        public override void ResetStats() {
            base.ResetStats();
            StopAllCoroutines();
        }

        /// <summary>
        /// Adds 1 to boost level and start coroutine to remove boost after a certian amount of seconds
        /// </summary>
        /// <param name="type">BoostType to be boosted</param>
        public void BoostStat(BoostType type) {
            var stat = GetOrCreateStat(type);
            stat.Value++;
            StartCoroutine(BoostRemoveTimer(type));
        }

        /// <summary>
        /// Removes boost level after a certian amount of seconds
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private IEnumerator BoostRemoveTimer(BoostType type) {
            yield return new WaitForSeconds(boostTime);
            var stat = GetOrCreateStat(type);
            stat.Value--;
        }

    }
}