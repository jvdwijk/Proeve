using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;

namespace PeppaSquad.Pickups.Stats {
    public class BoostStatHandler : ResettabeStatsHandler<BoostType> {

        private static BoostStatHandler instance;
        public static BoostStatHandler Instance => instance;

        private void Awake() {
            if (instance != null) {
                Destroy(this);
                return;
            }

            instance = this;
        }

    }
}