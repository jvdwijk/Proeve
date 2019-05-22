using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    public class ResettabeStatsHandler<StatName> : StatsHandler<StatName, ResettableStat<StatName>>
        where StatName : System.Enum { }

    public class ResettabeStatsHandler<StatName, StatType> : StatsHandler<StatName, StatType>
        where StatName : System.Enum
    where StatType : ResettableStat<StatName>, new() {

        public void ResetStats() {
            ForEachStat((ref StatType stat) => {
                stat.Reset();
            });
        }

    }
}