using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PeppaSquad.Stats.PlayerStats;
using PeppaSquad.Stats;

namespace PeppaSquad.Utils {
    public class TimerTimeCalculator : MonoBehaviour {

        [SerializeField] private Timer timer;   
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        private Stat<PlayerStatType> stat;
        private float timerValue;
        [SerializeField] private float timerBaseValue = 10;
        [SerializeField] private float timerMultiplicationValue= 1.2f;

        private void Awake(){
            stat = playerStatsHandler.GetOrCreateStat(PlayerStatType.Timer);
            TimerValueCalculator();
            stat.StatChanged += (value) => TimerValueCalculator();
        }

        public void TimerValueCalculator(){

            timerValue = timerBaseValue + (stat.Value * timerMultiplicationValue);
            timer.SetStartTime(timerValue);
        }

    }
}