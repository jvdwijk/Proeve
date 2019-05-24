using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PeppaSquad.Stats.PlayerStats;

namespace PeppaSquad.Currency
{
    public class BuyUpgrade : MonoBehaviour
    {
        [SerializeField] private PlayerStatType stat;
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private PlayerCurrency playerCurrency;
        [SerializeField] private TMP_Text currentLevelText;
        [SerializeField] private TMP_Text upgradeCostText;
        private int upgradeCost;
        private int currentLevel;
        public int Currentlevel => currentLevel;

        private void Start()
        {
            //After taking the saved stats, the values in the shop should update to stay consistent with that.
            UpdateText();

        }

        private void UpdateText()
        {
            upgradeCostText.text = Mathf.Abs(upgradeCost).ToString();
            currentLevelText.text = currentLevel.ToString();
        }

        public void Upgrade()
        {
            if (playerCurrency.Currency < Mathf.Abs(upgradeCost)) 
                return;

            playerCurrency.UpdateCurrency(upgradeCost);
            currentLevel += 1;
            var currentStat = playerStatsHandler.GetOrCreateStat(stat);
            currentStat.Value = currentLevel;
            upgradeCost = -(currentLevel * 7 + (currentLevel / 3 * 10) + 5);
            UpdateText();
        }

    }
}
