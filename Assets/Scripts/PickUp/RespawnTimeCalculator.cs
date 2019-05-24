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
        private float delay;
        private Stat<PlayerStatType> stat;

        public float Delay => delay;

        private void Awake(){
            stat = playerStatsHandler.GetOrCreateStat(PlayerStatType.BoostRespawn);
            RespawnCalculator();
            stat.StatChanged += (value) => RespawnCalculator();
        }

        private void RespawnCalculator(){
           delay = 3 + (10 / (stat.Value * 1.5f));
           pickUpsHandler.SetDelayValue(delay);
        }
    }
}