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

        /// <summary>
        /// Getting the prestige points stat.
        /// </summary>    
    private void Start(){
        prestigePointsStat = playerStatsHandler.GetOrCreateStat(PlayerStatType.PrestigePoints);
    }

        /// <summary>
        /// Calculate the prestige points and reset the current level of the player with a single click!
        /// </summary>
    public void Prestige(){
        PrestigeCalculation();
        ResetValues();
    }

        /// <summary>
        /// CalculatePrestigePoints for each stat
        /// </summary>
    private void PrestigeCalculation(){
        playerStatsHandler.ForEachStat(CalculatePrestigePoints);
    }

        /// <summary>
        /// Excluding prestige points and currency from the calculation, and updating prestige points with the new points gotten from prestiging.
        /// </summary>
     private void CalculatePrestigePoints(ref Stat<PlayerStatType> stat){
        if(stat.StatType == prestigePointsStat.StatType || stat.StatType == PlayerStatType.Currency)
            return;    
        int newPoints = ((int)stat.Value / divisionValue);
        prestigePointsStat.SetValue((int)prestigePointsStat.Value + newPoints);
        prestigePointsChanged?.Invoke((int)prestigePointsStat.Value);
    }

        /// <summary>
        /// ResetStat for each stat
        /// </summary>
    private void ResetValues(){
        playerStatsHandler.ForEachStat(ResetStat);
    }
        /// <summary>
        /// Excluding prestige points from the reset
        /// </summary>
    private void ResetStat(ref Stat<PlayerStatType> stat){
        if(stat.StatType != prestigePointsStat.StatType)
            stat.SetValue(0);
    }
}
}
