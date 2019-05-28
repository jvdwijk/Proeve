using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    public class ResettabeStatsHandler<StatName> : ResettabeStatsHandler<StatName, ResettableStat<StatName>>
        where StatName : System.Enum { }

    public class ResettabeStatsHandler<StatName, StatType> : StatsHandler<StatName, StatType>
        where StatName : System.Enum
    where StatType : ResettableStat<StatName>, new() {

        public virtual void ResetStats() {
            ForEachStat((ref StatType stat) => {
                stat.Reset();
            });
        }

    }
}