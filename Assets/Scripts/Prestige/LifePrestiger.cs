using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;
using System;

namespace PeppaSquad.Prestige{
public class LifePrestiger : MonoBehaviour
{

        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private int divisionValue;
        private Stat<PlayerStatType> prestigePointsStat;

        public event Action<int> prestigePointsChanged;
    private void Start(){
        prestigePointsStat = playerStatsHandler.GetOrCreateStat(PlayerStatType.PrestigePoints);
    }

    public void Prestige(){
        PrestigeCalculation();
        ResetValues();
    }

    private void PrestigeCalculation(){
        playerStatsHandler.ForEachStat(CalculatePrestigePoints);
    }


     private void CalculatePrestigePoints(ref Stat<PlayerStatType> stat){
        if(stat.StatType == prestigePointsStat.StatType || stat.StatType == PlayerStatType.Currency)
            return;    
        int newPoints = ((int)stat.Value / divisionValue);
        prestigePointsStat.SetValue((int)prestigePointsStat.Value + newPoints);
        prestigePointsChanged?.Invoke((int)prestigePointsStat.Value);
    }

    private void ResetValues(){
        playerStatsHandler.ForEachStat(ResetStat);
    }

    private void ResetStat(ref Stat<PlayerStatType> stat){
        if(stat.StatType != prestigePointsStat.StatType)
            stat.SetValue(0);
    }
}
}
