using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Currency;
using TMPro;

namespace PeppaSquad.Currency.UI {
    public class EndScreenCurrencyUI : MonoBehaviour {

        [SerializeField]
        private KillCurrencyHandler currencyHandler;

        [SerializeField]
        private TextMeshProUGUI currencyDisplay;

        private void Awake() {
            currencyHandler.CurrencyCounterReset += UpdateCurrencyUI;
        }

        private void OnEnable() {
            UpdateCurrencyUI(currencyHandler.CollectedCurrencyLastRound);
        }

        public void UpdateCurrencyUI(int newValue) {
            currencyDisplay.text = newValue.ToString();
        }

    }
}