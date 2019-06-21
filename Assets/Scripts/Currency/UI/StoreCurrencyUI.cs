using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PeppaSquad.Prestige;
using PeppaSquad.Stats;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Currency.UI {
    public class StoreCurrencyUI : MonoBehaviour {
        [SerializeField]
        private PlayerCurrency currencyHandler;
        [SerializeField] private PlayerStatType stat;
        [SerializeField] private LifePrestiger lifePrestiger;
        [SerializeField] private PlayerStatsHandler playerStatsHandler;

        [SerializeField]
        private TextMeshProUGUI currencyDisplay;

        private void Awake() {
            currencyHandler.CurrencyChanged += UpdateCurrencyUI;
            lifePrestiger.prestigePointsChanged += (currPrestigePoints) => UpdateCurrencyUI(currencyHandler.Currency);
            playerStatsHandler.GetOrCreateStat(stat).StatChanged += (clear) => UpdateCurrencyUI((int)playerStatsHandler.GetOrCreateStat(stat).Value);
        }

        private void OnEnable() {
            UpdateCurrencyUI(currencyHandler.Currency);
        }

        public void UpdateCurrencyUI(int newValue) {
            currencyDisplay.text = newValue.ToString();
        }
    }
}