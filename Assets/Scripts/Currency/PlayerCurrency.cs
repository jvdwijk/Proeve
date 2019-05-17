using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PeppaSquad.Stats.PlayerStats;
using PeppaSquad.Stats;
using PeppaSquad.Enemies;

namespace PeppaSquad.Currency
{
    public class PlayerCurrency : MonoBehaviour
    {
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private EnemyTracker enemyTracker;
        [SerializeField] private TMP_Text currencyText;
        public int Currency;
        private Stat<PlayerStatType> statCurrency;

        private void Start()
        {
            statCurrency = playerStatsHandler.GetOrCreateStat(PlayerStatType.Currency);
            enemyTracker.OnEnemyDefeat += () => AddCurrency(enemyTracker.EnemyLevel * 3);
        }

        public void AddCurrency(int amount)
        {
            Currency += amount;
            statCurrency.SetValue(Currency);
            UpdateCurrency();
        }

        public void SubtractCurrency(int amount)
        {
            if (Currency >= amount)
            {
                Currency -= amount;
                statCurrency.SetValue(Currency);
                UpdateCurrency();
            }
            else
            {
                print("You do not have enough currency to execute this action.");
                //TODO Visual or Audio response so the player knows their HELP IS REQUIRED IN ANOTHER SETTLEMENT
            }

        }

        private void UpdateCurrency()
        {
            currencyText.text = Currency.ToString();
        }
    }
}
