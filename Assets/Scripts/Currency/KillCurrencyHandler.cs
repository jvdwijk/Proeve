using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Enemies;
using PeppaSquad.Pickups.Stats;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Currency {
    public class KillCurrencyHandler : Resetter {

        [SerializeField]
        private PlayerCurrency playerCurrency;
        [SerializeField]
        private EnemyTracker enemyTracker;
        [SerializeField]
        private float moneyLevelMultiplier = 3;
        [SerializeField, Range(0, 100)]
        private float BoostProcentAmount = 3;

        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private PlayerStatType stat;
        private bool resetNextKill = false;
        private Stat<BoostType> currencyBoostStat;

        public int CollectedCurrency { get; private set; } = 0;
        public int CollectedCurrencyLastRound { get; private set; } = 0;

        public event Action<int> CurrencyUpdated;
        public event Action<int> CurrencyCounterReset;

        private void Awake() {
            enemyTracker.OnEnemyDefeat += OnKill;
        }

        private void Start() {
            currencyBoostStat = BoostStatHandler.Instance.GetOrCreateStat(BoostType.Credits);
        }

        public void OnKill() {
            int killProfit = (int) ((enemyTracker.EnemyLevel * moneyLevelMultiplier));
            killProfit += (int) (killProfit / 100f * (BoostProcentAmount * currencyBoostStat.Value) * (1 + playerStatsHandler.GetOrCreateStat(stat).Value / 10));
            playerCurrency.UpdateCurrency(killProfit);
            CollectedCurrency += killProfit;
            CurrencyUpdated?.Invoke(CollectedCurrency);
        }

        public override void TriggerReset() {
            CollectedCurrencyLastRound = CollectedCurrency;
            CollectedCurrency = 0;
            CurrencyCounterReset?.Invoke(CollectedCurrency);
        }

    }
}