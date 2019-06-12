using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PeppaSquad.Currency.UI {
    public class GameCurrencyUI : MonoBehaviour {
        [SerializeField]
        private KillCurrencyHandler currencyHandler;

        [SerializeField]
        private TextMeshProUGUI currencyDisplay;

        private void Awake() {
            currencyHandler.CurrencyUpdated += UpdateCurrencyUI;
        }

        private void OnEnable() {
            UpdateCurrencyUI(currencyHandler.CollectedCurrency);
        }

        public void UpdateCurrencyUI(int newValue) {
            currencyDisplay.text = newValue.ToString();
        }
    }
}