using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    public class StatsHandler<StatName> : StatsHandler<StatName, Stat<StatName>>
        where StatName : System.Enum { }

    public class StatsHandler<StatName, StatType> : MonoBehaviour
    where StatName : System.Enum
    where StatType : Stat<StatName> {

        private Dictionary<StatName, Stat<StatName>> stats = new Dictionary<StatName, Stat<StatName>>();

        /// <summary>
        /// Called when a new stat is created.
        /// </summary>
        public event Action<Stat<StatName>> StatCreated;

        /// <summary>
        /// Creates stat if it does not exist. Returns stat with the given name.
        /// </summary>
        /// <param name="statName">Name of the stat</param>
        /// <returns>Stat associated with given stat name</returns>
        public Stat<StatName> GetOrCreateStat(StatName statName) {
            if (!stats.ContainsKey(statName))
                CreateStat(statName);

            return stats[statName];
        }

        /// <summary>
        /// Returns stat with a given name.
        /// </summary>
        /// <param name="statName">Name of the stat.</param>
        /// <returns>stat</returns>
        public Stat<StatName> GetStat(StatName statName) {
            if (!stats.ContainsKey(statName))
                return null;

            return stats[statName];
        }

        public void SetStatValue(StatName statName, float statValue) {
            var stat = GetStat(statName);
            stat.Value = statValue;
        }

        /// <summary>
        /// Creates a new stat.
        /// </summary>
        /// <param name="statName"></param>
        public void CreateStat(StatName statName) {
            if (stats.ContainsKey(statName))
                return;

            var newStat = new Stat<StatName>(statName);
            stats.Add(statName, newStat);
            StatCreated?.Invoke(newStat);
        }
    }
}