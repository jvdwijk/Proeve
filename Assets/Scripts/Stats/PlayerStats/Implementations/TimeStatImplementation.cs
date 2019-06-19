using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Pickups.Stats;
using PeppaSquad.Utils;

namespace PeppaSquad.Stats.PlayerStats.Implementation {
    public class TimeStatImplementation : MonoBehaviour {

        [SerializeField]
        private float startTime = 5, levelIncrease = 0.3f;

        [SerializeField, Range(0, 100)]
        private float boostProcentAmount;

        [Header("References"), SerializeField]
        private Timer timer;

        [SerializeField]
        private PlayerStatsHandler playerstats;
        private BoostStatHandler booststats;

        private Stat<PlayerStatType> playerStat;

        private void Awake() {
            playerStat = playerstats.GetOrCreateStat(PlayerStatType.Timer);
            playerStat.StatChanged += (stat) => SetTimer();
            SetTimer();
        }

        private void Start() {
            booststats = BoostStatHandler.Instance;
            booststats.GetOrCreateStat(BoostType.Time).StatChanged += (stat) => {
                if (stat.Value > stat.PreviousValue)
                    return;

                timer.AddTime(CalculateTime() / 100 * boostProcentAmount);
            };
        }

        private void SetTimer() {
            var time = CalculateTime();
            timer.SetStartTime(time);
        }

        private float CalculateTime() {
            return startTime + levelIncrease * playerStat.Value;
        }

    }
}