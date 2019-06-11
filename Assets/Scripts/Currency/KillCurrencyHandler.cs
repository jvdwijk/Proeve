using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Enemies;

namespace PeppaSquad.Currency {
    public class KillCurrencyHandler : Resetter {

        [SerializeField]
        private PlayerCurrency playerCurrency;
        [SerializeField]
        private EnemyTracker enemyTracker;

        private bool resetNextKill = false;

        public int CollectedCurrency { get; private set; } = 0;
        public int CollectedCurrencyLastRound { get; private set; } = 0;

        public event Action<int> CurrencyUpdated;
        public event Action<int> CurrencyCounterReset;

        private void Awake() {
            enemyTracker.OnEnemyDefeat += OnKill;
        }

        public void OnKill() {
            int killProfit = enemyTracker.EnemyLevel * 3;
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