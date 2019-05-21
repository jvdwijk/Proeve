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
        private int currency;
        public int Currency => currency;
        [SerializeField] private PlayerStatsHandler playerStatsHandler;
        [SerializeField] private EnemyTracker enemyTracker;
        [SerializeField] private TMP_Text currencyText;
        private Stat<PlayerStatType> statCurrency;

        private void Start()
        {
            statCurrency = playerStatsHandler.GetOrCreateStat(PlayerStatType.Currency);
            enemyTracker.OnEnemyDefeat += () => UpdateCurrency(enemyTracker.EnemyLevel * 3);
        }
        public void UpdateCurrency(int updateAmount)
        {
            currency += updateAmount;
            statCurrency.SetValue(currency);
            currencyText.text = currency.ToString();
        }
    }
}
