using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PeppaSquad.Currency.UI {
    public class StoreCurrencyUI : MonoBehaviour {
        [SerializeField]
        private PlayerCurrency currencyHandler;

        [SerializeField]
        private TextMeshProUGUI currencyDisplay;

        private void Awake() {
            currencyHandler.CurrencyChanged += UpdateCurrencyUI;
        }

        private void OnEnable() {
            UpdateCurrencyUI(currencyHandler.Currency);
        }

        public void UpdateCurrencyUI(int newValue) {
            currencyDisplay.text = newValue.ToString();
        }
    }
}