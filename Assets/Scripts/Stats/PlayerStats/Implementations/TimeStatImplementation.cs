using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Utils;

namespace PeppaSquad.Stats.PlayerStats.Implementation {
    public class TimeStatImplementation : MonoBehaviour {

        [SerializeField]
        private float startTime = 5, levelIncrease = 0.3f;

        [Header("References"), SerializeField]
        private Timer timer;

        [SerializeField]
        private PlayerStatsHandler playerstats;
        private Stat<PlayerStatType> stat;

        private void Awake() {
            stat = playerstats.GetOrCreateStat(PlayerStatType.Timer);
            stat.StatChanged += (stat) => SetTimer();
            SetTimer();
        }

        private void SetTimer() {
            var time = CalculateTime();
            timer.SetStartTime(time);
        }

        private float CalculateTime() {
            return startTime + levelIncrease * stat.Value;
        }

    }
}