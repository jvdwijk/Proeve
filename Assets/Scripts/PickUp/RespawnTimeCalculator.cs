using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Stats.PlayerStats;
using PeppaSquad.Stats;

namespace PeppaSquad.Pickups
{
    public class RespawnTimeCalculator : MonoBehaviour
    {
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private PickupsHandler pickUpsHandler;
        [SerializeField] private int respawnBaseValue;
        [SerializeField] private float respawnMultiplicationValue;
        [SerializeField] private int respawnDivisibleValue; 
        private float delay;
        private Stat<PlayerStatType> stat;

        public float Delay => delay;

        private void Awake(){
            stat = playerStatsHandler.GetOrCreateStat(PlayerStatType.BoostRespawn);
            RespawnCalculator();
            stat.StatChanged += (value) => RespawnCalculator();
        }

        private void RespawnCalculator(){
           delay = respawnBaseValue + (respawnDivisibleValue / (stat.Value * respawnMultiplicationValue));
           pickUpsHandler.SetDelayValue(delay);
        }
    }
}