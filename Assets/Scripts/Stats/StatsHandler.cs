using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeppaSquad.Stats {

    public class StatsHandler<StatName> : StatsHandler<StatName, Stat<StatName>>
        where StatName : System.Enum { }

    public class StatsHandler<StatName, StatType> : MonoBehaviour
    where StatName : System.Enum
    where StatType : Stat<StatName>, new() {

        private Dictionary<StatName, StatType> stats = new Dictionary<StatName, StatType>();

        /// <summary>
        /// Called when a new stat is created.
        /// </summary>
        public event Action<StatType> StatCreated;

        public delegate void EditStat(ref StatType stat);

        /// <summary>
        /// Creates stat if it does not exist. Returns stat with the given name.
        /// </summary>
        /// <param name="statName">Name of the stat</param>
        /// <returns>Stat associated with given stat name</returns>
        public StatType GetOrCreateStat(StatName statName) {
            if (!stats.ContainsKey(statName))
                CreateStat(statName);

            return stats[statName];
        }

        /// <summary>
        /// Returns stat with a given name.
        /// </summary>
        /// <param name="statName">Name of the stat.</param>
        /// <returns>stat</returns>
        public StatType GetStat(StatName statName) {
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

            StatType newStat = new StatType();
            newStat.SetType(statName);
            stats.Add(statName, newStat);
            StatCreated?.Invoke(newStat);
        }

        public void ForEachStat(EditStat call) {
            foreach (var statKeyValue in stats) {
                StatType stat = statKeyValue.Value;
                call?.Invoke(ref stat);
            }
        }
    }
}