using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;

namespace PeppaSquad.Pickups.Stats {
    public class BoostStatHandler : ResettabeStatsHandler<BoostType> {

        [SerializeField]
        private float boostTime;

        private static BoostStatHandler instance;
        public static BoostStatHandler Instance => instance;

        private void Awake() {
            if (instance != null) {
                Destroy(this);
                return;
            }

            instance = this;
        }

        public override void ResetStats() {
            base.ResetStats();
            StopAllCoroutines();
        }

        public void BoostStat(BoostType type) {
            var stat = GetOrCreateStat(type);
            stat.Value++;
            StartCoroutine(BoostRemoveTimer(type));
        }

        private IEnumerator BoostRemoveTimer(BoostType type) {
            yield return new WaitForSeconds(boostTime);
            var stat = GetOrCreateStat(type);
            stat.Value--;
        }

    }
}