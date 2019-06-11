using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PeppaSquad.Enemies;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;
using TMPro;

namespace PeppaSquad.Currency {
    public class PlayerCurrency : MonoBehaviour {
        [SerializeField] private int currency;
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        private Stat<PlayerStatType> statCurrency;

        public int Currency => currency;

        public event Action<int> CurrencyChanged;

        /// <summary>
        /// This start is used to add updatecurrency to the onenemydefeat action. It also assigns a stattype to statcurrency
        /// </summary>
        private void Start() {
            statCurrency = playerStatsHandler.GetOrCreateStat(PlayerStatType.Currency);
            currency = (int) statCurrency.Value;
        }

        /// <summary>
        /// Updates the players current amount of currency according to any negative/positive changes.
        /// </summary>
        /// <param name="updateAmount"></param>
        public void UpdateCurrency(int updateAmount) {
            currency += updateAmount;
            statCurrency.SetValue(currency);

            CurrencyChanged?.Invoke(currency);
        }
    }
}