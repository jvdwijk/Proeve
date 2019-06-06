using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    /// <summary>
    /// A resetable version of the StatsHandler class
    /// </summary>
    /// <typeparam name="StatName">The list in the form of an enum</typeparam>
    public class ResettabeStatsHandler<StatName> : ResettabeStatsHandler<StatName, ResettableStat<StatName>>
        where StatName : System.Enum { }

    /// <summary>
    /// A resetable version of the StatsHandler class
    /// </summary>
    /// <typeparam name="StatName">The list in the form of an enum</typeparam>
    /// <typeparam name="StatType">A custom type of stat</typeparam>
    public class ResettabeStatsHandler<StatName, StatType> : StatsHandler<StatName, StatType>
        where StatName : System.Enum
    where StatType : ResettableStat<StatName>, new() {

        /// <summary>
        /// Resets all stats
        /// </summary>
        public virtual void ResetStats() {
            ForEachStat((ref StatType stat) => {
                stat.Reset();
            });
        }

    }
}