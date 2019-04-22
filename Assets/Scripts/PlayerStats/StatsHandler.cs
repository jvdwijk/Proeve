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

        private Dictionary<StatName, Stat<StatName>> stats;

        public event Action<Stat<StatName>> StatCreated;

        public Stat<StatName> GetOrCreateStat(StatName statType) {
            if (!stats.ContainsKey(statType))
                CreateStat(statType);

            return stats[statType];
        }

        public Stat<StatName> GetStat(StatName statType) {
            if (!stats.ContainsKey(statType))
                return null;

            return stats[statType];
        }

        public void SetStatValue(StatName statType, float statValue) {
            var stat = GetStat(statType);
            stat.Value = statValue;
        }

        private void CreateStat(StatName statType) {
            if (stats.ContainsKey(statType))
                return;

            var newStat = new Stat<StatName>(statType);
            stats.Add(statType, newStat);
            StatCreated?.Invoke(newStat);
        }
    }
}