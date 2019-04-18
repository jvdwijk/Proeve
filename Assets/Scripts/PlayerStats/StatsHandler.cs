using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler<T> : MonoBehaviour 
where T : System.Enum 
{
    private Dictionary<T, Stat<T>> stats;

    public event Action<Stat<T>> StatCreated;

    public Stat<T> GetStat(T statType){
        if (!stats.ContainsKey(statType))
            CreateStat(statType);

        return stats[statType];
    }

    public void SetStatValue(T statType, float statValue){
        var stat = GetStat(statType);
        stat.Value = statValue;
    }

    private void CreateStat(T statType){
        if (stats.ContainsKey(statType))
            return;

        var newStat = new Stat<T>(statType);
        stats.Add(statType, newStat);
        StatCreated?.Invoke(newStat);
    }
}
